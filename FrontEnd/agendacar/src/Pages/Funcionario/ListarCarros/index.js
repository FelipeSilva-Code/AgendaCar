import React from "react";
import "./styles.css"
import { useState } from "react";
import { Link } from "react-router-dom";
import ContainerTotal from "../../../Components/ContainerTotal";
import TestDriveApi from "../../../Services/TestDriverApi";
import { toast, ToastContainer } from "react-toastify";
import { useEffect } from "react";

const api = new TestDriveApi();

export default function ListarCarros() {
  const [carrosListados, setCarrosListados] = useState([]);

  const buscarCarro = async (busca) => {
    try {

        if(busca == undefined)
            busca = "";
        
            const resp = await api.buscarCarro(busca);
        
            setCarrosListados(resp);
    } catch (e) {
            toast.error(e.response.data);
            console.log(e.response)
            setCarrosListados([]);
    }
  };

  const excluirCarro = async (idCarro) => {
      try {

        const x = window.confirm("Você irá excluir um carro do sistema.")
        
        if(x === true){
            await api.deletarCarro(idCarro);
            buscarCarro("");
        }
          
      } catch (e) {
          toast.error(e.response.data.mensagem);
      }
  }

   useEffect(() => {
     buscarCarro("");
   }, []);

  return (
    <ContainerTotal>
        <ToastContainer/>
      <h3>Todos os Carros Cadastrados</h3>

      <div className="procurarCarros">
        <label>
          Procurar carros:
          <input placeholder="insira a marca, modelo ou cor do carro" onChange={(e) => buscarCarro(e.target.value)} type="search" className="form-control" />
        </label>
      </div>

      {carrosListados.map((item) => (
        <div className="infoCarro">
          <h4>
            {item.marca} {item.modelo} - {item.cor} - Qtd. Disponível: {item.qtdDisponivel} 
          </h4>
           
          <div className="ladoDireitoCarroListado">
            <button onClick={() => excluirCarro(item.id)} className="btn btn-outline-danger">Excluir Carro</button>
            <Link to={{pathname:"/Funcionario/VerInfoCarro", state:item.id}}>Ver Mais / Alterar Info </Link>
          </div>
        </div>
      ))}
    </ContainerTotal>
  );
}
