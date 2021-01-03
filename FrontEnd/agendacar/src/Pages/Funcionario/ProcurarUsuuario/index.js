import React from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotal";
import { Link } from "react-router-dom";
import { useState } from "react";
import TestDriverApi from "../../../Services/TestDriverApi";
import { toast, ToastContainer } from "react-toastify";
import { useEffect } from "react";

const api = new TestDriverApi();

export default function ProcurarUsuario () {
    
    const [nome, setNome] = useState("");
    const [perfil, setPerfil] = useState("Cliente");
    const [usuarios, setUsuarios] = useState([]);

    const pegarInfoCliente = async (nomePassado) => {
        try {
            const resp = await api.pegarInfoCliente(nomePassado);
            
            setUsuarios(resp)
        } catch (e) {
            setUsuarios([])
            toast.error(e.response.data.mensagem);
            console.log("erro")
        }
    }

    const pegarInfoFuncionario = async (nomePassado) => {

        try {
            const resp = await api.pegarInfoFuncionario(nomePassado);
            setUsuarios(resp);
        } catch (e) {
            setUsuarios([]);
            toast.error(e.response.data.mensagem)   
            console.log(e.response);
        }
    }

    const gerenciar = (nomePassado, perfilPassado) => {
        setNome(nomePassado);
        setPerfil(perfilPassado)

        if(perfilPassado == "Cliente")
            pegarInfoCliente(nomePassado);
        else
            pegarInfoFuncionario(nomePassado);
    }

    useEffect(() => {
      gerenciar(nome, perfil);
    }, []);

    return(
        <ContainerTotal>
            <ToastContainer/>
            <h3>Procurar Usuários</h3>

            <div className="procurarUsuario">
                <label>
                Digite o nome do usuário:
                <input onChange={(e) => gerenciar(e.target.value, perfil)} placeholder="insira o nome" type="search" className="form-control" />
                </label>

                <label>
                Escolha o Perfil
                <select onChange={(e) => gerenciar (nome, e.target.value )} className="form-control">
                    <option value="Cliente">Cliente</option>
                    <option value="Funcionario">Funcionário</option>
                </select>
                </label>
            </div>

                {usuarios.map(item => 
                    <div className="infoUsuario">
                    <h4>
                        {item.nome} - {item.telefone} - {item.email}
                    </h4>
                    
                    <div className="ladoDireitoUsuarioListado">
                        <button className="btn btn-outline-danger">Excluir Usuário</button>
                        <Link to={{pathname:""}}>Ver Mais </Link>
                    </div>
                    </div>
                )}
         
        </ContainerTotal>
    )
}