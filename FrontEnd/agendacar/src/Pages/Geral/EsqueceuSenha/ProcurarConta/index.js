import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotalDeslogado";
import { useHistory } from "react-router-dom";
import TestDriveApi from "../../../../Services/TestDriverApi";
import {toast, ToastContainer} from "react-toastify";
import { useState } from "react";

const api = new TestDriveApi();


export default function ProcuararConta () {

    const [email, setEmail] = useState("");

    const procurarConta = async () => {
        try {
            const resp = await api.procurarConta(email);
            history.push({ pathname: "/EnviarCodigo", state:resp });
        } catch (e) {
            toast.error(e.response.data.mensagem);
        }
    }

    const telaDeLogin = () => {
        history.push({pathname:"/login"})
    }


    const history = useHistory();

    return(
        <ContainerTotal>
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