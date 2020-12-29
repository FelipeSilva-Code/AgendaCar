import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotal";
import { useHistory } from "react-router-dom";


export default function ProcuararConta () {

    const history = useHistory();

    return(
        <ContainerTotal>
            <div className="containerProcurarConta">
                <div className="divEncontrarConta">
                    <h4>Encontrar Conta</h4>
                </div>

                <div className="divInputEncontrarConta">
                    <label>Insira seu email para procurar sua conta
                        <input placeholder="Email" className="form-control" />
                    </label>
                </div>

                <div className="divBtnsEncotrarConta">
                    <button className="btn btn-success">Procurar</button>
                    <button className="btn btn-danger">Cancelar</button>
                </div>
            </div>
        </ContainerTotal>
    )
}