import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotalDeslogado";
import TestDriveApi from "../../../../Services/TestDriverApi";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";

const api = new TestDriveApi();

export default function InserirCodigo (props) {

    const [responseInfoUsuario, setResponseInfoUsuario] = useState (props.location.state.responseInfoUsuario);
    const [codigo, setCodigo] = useState(props.location.state.cdg);
    const [cdgPassado, setCdgPassado] = useState();

    const history = useHistory();

    const verSeCodigoEstaCorreto = () => {
        if(codigo == cdgPassado)
            history.push({pathname:"/NovaSenha", state:responseInfoUsuario});
        else
            toast.error("O código está incorreto ou ja expirou.")    
    }

    const voltar = () => {
        history.push("/login");
    }

    const irParaTelaDeEnviarCodigo = () => {
        history.goBack();
    }

    return(
        <ContainerTotal>
            <ToastContainer/>
            <div className="containerInserirCodigo">
                <div className="divInsiraCodigoSeguranca">
                    <h4>Insira o código de segurança</h4>
                </div>

                <div className="divVerificarEmail">
                    <p>Verifique se voçê recebeu um email com seu código. O código tem 5 caracteres</p>
                     
                     <div className="digitarCodigo">
                        <input onChange={e => setCdgPassado(e.target.value)} className="form-control" type="text" placeholder="Insira o código"></input>
                        <p>Enviamos seu código para: <br/>{responseInfoUsuario.email}</p>
                     </div>   
                </div>

                <div className="divBaixoInserirCodigo">
                    <div className="divBtnsInserirCodigo">
                        <button onClick={verSeCodigoEstaCorreto} className="btn btn-success">Continuar</button>
                        <button onClick={voltar} className="btn btn-danger">Cancelar</button>
                    </div>
                    <div>
                        <p onClick={irParaTelaDeEnviarCodigo} className="reenviarCodigo">Reenviar Código</p>
                    </div>    
                </div>

            </div>
        </ContainerTotal>
    )
}