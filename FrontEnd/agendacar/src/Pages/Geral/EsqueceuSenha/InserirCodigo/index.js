import React from "react";
import "./styles.css";
import ContainerTotal from "../../../../Components/ContainerTotal";

export default function InserirCodigo () {
    return(
        <ContainerTotal>
            <div className="containerInserirCodigo">
                <div className="divInsiraCodigoSeguranca">
                    <h4>Insira o código de segurança</h4>
                </div>

                <div className="divVerificarEmail">
                    <p>Verifique se voçê recebeu um email com seu código. O código tem 6 caracteres</p>
                     
                     <div className="digitarCodigo">
                        <input className="form-control" type="text" placeholder="Insira o código"></input>
                        <p>Enviamos seu código para: <br/> felipecsilva207@gmail.com</p>
                     </div>   
                </div>

                <div className="divBaixoInserirCodigo">
                    <div className="divBtnsInserirCodigo">
                        <button className="btn btn-success">Continuar</button>
                        <button className="btn btn-danger">Cancelar</button>
                    </div>
                    <div>
                        <p className="reenviarCodigo">Reenviar Código</p>
                    </div>    
                </div>

            </div>
        </ContainerTotal>
    )
}