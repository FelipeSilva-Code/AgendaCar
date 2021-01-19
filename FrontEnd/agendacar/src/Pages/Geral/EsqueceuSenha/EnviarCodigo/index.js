import React, {useRef} from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotalDeslogado";
import { useHistory } from "react-router-dom";
import { useState } from "react";
import TestDriveApi from "../../../../Services/TestDriverApi";
import { useEffect } from "react";
import {toast, ToastContainer} from "react-toastify";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriveApi();


export default function EnviarCodigo (props) {

    const [responseInfoUsuario, setResponseInfoUsuario] = useState(props.location.state);
    const [url, setUrl] = useState(props.location.state.nomeImagem);
    
    const history = useHistory();

     const loadingBar = useRef(null);

     const gerarCodigo = async () => {
        
        try {

            loadingBar.current.continuousStart();

            const cdg = await api.gerarCodigo(responseInfoUsuario.email);
     
            loadingBar.current.complete();

            history.push({pathname:"/InserirCodigo", state:{
                         responseInfoUsuario, cdg
            }})
            
        } catch (e) {
            loadingBar.current.complete();
            toast.error(e.response.data.mensagem);
        }
    }


    const voltar = () => {
        history.goBack();
    }

    return(
        <ContainerTotal>
            <LoadingBar height={7} color="red" ref={loadingBar} />
            <ToastContainer/>

            <div className="containerEnviarCodigo">
                <div className="divRedefinaSenhaEnviarCodigo">
                    <h4>Redefina Sua Senha</h4>
                </div>

                <div className="divDadosDaPessoaEnviarCodigo">
                    <div className="ladoDireitoEnviarCodigo">
                        <h5>O Código será enviado para:</h5>
                        <h6>{responseInfoUsuario.email}</h6>
                    </div>

                    <div className="ladoEsquerdoEnviarCodigo">
                        <div className="divImagemUsuarioEnviarCodigo">
                            <img src={api.buscarFotoUsuario(url)}/>
                        </div>    
                        <h6>{responseInfoUsuario.nomeUsuario}</h6>
                    </div>
                </div>

                <div className="divBtnsEnviarCodigo">
                    <button onClick={gerarCodigo} className="btn btn-success">Continuar</button>
                    <button onClick={voltar} className="btn btn-danger">Não é você?</button>
                </div>

            </div>
            
        </ContainerTotal>
    )
}