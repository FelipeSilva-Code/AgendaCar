import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotalDeslogado";
import { useHistory } from "react-router-dom";
import { useState } from "react";
import TestDriveApi from "../../../../Services/TestDriverApi";
import { toast, ToastContainer } from "react-toastify";

const api = new TestDriveApi();

export default function NovaSenha (props) {
    
    const history = useHistory();

    const [idLogin, setIdLogin] = useState(props.location.state.idLogin);
    const [novaSenha, setNovaSenha] = useState();
    const [repitaSenha, setRepitaSenha] = useState();

    const alterarSenha = async () => {

        try {

            const request = {
              SenhaAtual: "",
              NovaSenha1: novaSenha,
              NovaSenha2: repitaSenha,
            };

            await api.mudarSenhaPorqueEsqueceu(request, idLogin);

            history.push("/Login");
            
        } catch (e) {
            
            toast.error(e.response.data.mensagem);

        }
    }
    
    const voltar = () => {
        history.push("/login");
    }

    return(
        <ContainerTotal>
            <ToastContainer/>
            <div className="containerNovaSenha">
                <div className="divAlterarSenhaNova">
                    <h4>Alterar Senha</h4>
                </div>

                <div className="divAdicionarNovaSenha">
                    <label>Nova Senha
                        <input onChange={e => setNovaSenha(e.target.value)} type="password" className="form-control" />
                    </label>

                     <label>Repita a Senha
                        <input onChange={e => setRepitaSenha(e.target.value)} type="password" className="form-control" />
                    </label>
                </div>
                
                <div className="divBtnsNovaSenha">
                    <button onClick={alterarSenha} className="btn btn-success">Confirmar</button>
                    <button onClick={voltar} className="btn btn-danger">Cancelar</button>
                </div>
            </div>
        </ContainerTotal>
    )
}