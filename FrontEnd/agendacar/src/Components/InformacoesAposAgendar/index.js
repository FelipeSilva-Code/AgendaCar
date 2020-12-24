import React from "react";
import { useHistory } from "react-router-dom";
import "./styles.css";

export default function InformacoesAposAgendar() {

    const history = useHistory();
    
    const voltar = () => {
        history.goBack();
    }
    return(
        <div className="containerAposAgendar">
            <div className="divInfoAgendar">
                <h4>Você agendou um test drive, e agora está esperando 
                    a aprovação de um funcionário.
                    Quando o funcionário aprovar, você irá receber um email de 
                    confirmação. Para ver os detalhes do seu agendamento
                    é só ir em "meus agendamentos" e depois em "outros"
                </h4>
                <button onClick={voltar} className="btn btn-success">&nbsp; &nbsp; Ok &nbsp; &nbsp;</button>
            </div>
        </div>
    )
}