import React, {useRef} from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotalDeslogado";
import { useHistory } from "react-router-dom";
import TestDriveApi from "../../../../Services/TestDriverApi";
import {toast, ToastContainer} from "react-toastify";
import { useState } from "react";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriveApi();


export default function ProcuararConta () {

    const [email, setEmail] = useState("");

    const loadingBar = useRef(null);

    const procurarConta = async () => {
        try {
            loadingBar.current.continuousStart();
            const resp = await api.procurarConta(email);
            loadingBar.current.complete();
            history.push({ pathname: "/EnviarCodigo", state:resp });
        } catch (e) {
            loadingBar.current.complete();
            toast.error(e.response.data.mensagem);
        }
    }

    const telaDeLogin = () => {
        history.push({pathname:"/login"})
    }


    const history = useHistory();

    return(
        <ContainerTotal>
            <LoadingBar height={7} color="red" ref={loadingBar} />
            <ToastContainer/>
            <div className="containerProcurarConta">
                <div className="divEncontrarConta">
                    <h4>Encontrar Conta</h4>
                </div>

                <div className="divInputEncontrarConta">
                    <label>Insira seu email para procurar sua conta
                        <input  onChange={e => setEmail(e.target.value)} placeholder="Email" className="form-control" />
                    </label>
                </div>

                <div className="divBtnsEncotrarConta">
                    <button onClick={procurarConta} className="btn btn-success">Procurar</button>
                    <button onClick={telaDeLogin} className="btn btn-danger">Cancelar</button>
                </div>
            </div>
        </ContainerTotal>
    )
}