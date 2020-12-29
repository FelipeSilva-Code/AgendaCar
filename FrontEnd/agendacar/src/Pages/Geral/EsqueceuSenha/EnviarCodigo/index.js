import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotal";
import { useHistory } from "react-router-dom";


export default function EnviarCodigo () {
    const history = useHistory();

    return(
        <ContainerTotal>

            <div className="containerEnviarCodigo">
                <div className="divRedefinaSenhaEnviarCodigo">
                    <h4>Redefina Sua Senha</h4>
                </div>

                <div className="divDadosDaPessoaEnviarCodigo">
                    <div className="ladoDireitoEnviarCodigo">
                        <h5>O Código será enviado para:</h5>
                        <h6>felipecsilva207@gmail.com</h6>
                    </div>

                    <div className="ladoEsquerdoEnviarCodigo">
                        <img src=""/>
                        <h5>Felipe Conceição</h5>
                    </div>
                </div>

                <div className="divBtnsEnviarCodigo">
                    <button className="btn btn-success">Continuar</button>
                    <button className="btn btn-danger">Não é você?</button>
                </div>

            </div>
            
        </ContainerTotal>
    )
}