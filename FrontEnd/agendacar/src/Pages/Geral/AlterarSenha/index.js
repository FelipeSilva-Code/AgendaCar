import React, { useState, useRef } from "react";
import ContainerTotal from "../../../Components/ContainerTotalLogado"
import "./styles.css";
import { useHistory } from "react-router-dom";
import {toast, ToastContainer} from "react-toastify"
import TestDriveApi from "../../../Services/TestDriverApi";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriveApi();

export default function AlterarSenha (props) {

    const [idUsuario, setIdUsuario] = useState(props.location.state.idUsuario);
    const [senhaAtual, setSenhaAtual] = useState();
    const [novaSenha1, setNovaSenha1] = useState();
    const [novaSenha2, setNovaSenha2] = useState();

    const history = useHistory();

    const loadingBar = useRef(null);

    const alterarSenha = async () => {

        try {

            loadingBar.current.continuousStart();

            const req = {
              "SenhaAtual": senhaAtual,
              "NovaSenha1": novaSenha1,
              "NovaSenha2": novaSenha2,
            };

            if(props.location.state.perfil == "Cliente")
                await api.alterarSenhaCliente(req, idUsuario);
            else
                await api.alterarSenhaFuncionario(req, idUsuario) ;    

            loadingBar.current.complete();

            voltarParaTelaDeVerInformacoes();
       
        } catch (e) {
            loadingBar.current.complete();
            toast.error(e.response.data.mensagem);
        }

    }

    const voltarParaTelaDeVerInformacoes = () => {
        history.goBack();
    }

    return (
      <ContainerTotal idUsuario={idUsuario} perfil="Cliente">
        <LoadingBar height={7} color="red" ref={loadingBar} />
        <ToastContainer/>
        <div className="divAlterarSenha">

            <h3>Alterar Senha</h3>

            <div className="divInputsAlterar">
                <label>
                    Senha Atual:<input onChange={e => setSenhaAtual(e.target.value)} type="password" className="form-control"></input>
                </label>

                <label>
                    Nova Senha:<input onChange={e => setNovaSenha1(e.target.value)} type="password" className="form-control"></input>
                </label>

                <label>
                    Repita a Senha<input onChange={e => setNovaSenha2(e.target.value)} type="password" className="form-control"></input>
                </label>
            </div>
         
            <div className="divBtnAlterarSenha">
                <button onClick={voltarParaTelaDeVerInformacoes} className="btn btn-danger">Cancelar</button>
                <button onClick={alterarSenha} className="btn btn-success">Confirmar</button>
            </div>
 
        </div>
      </ContainerTotal>
    );
}