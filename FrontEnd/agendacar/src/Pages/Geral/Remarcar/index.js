import React, {useRef} from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotalLogado";
import TestDriverApi from "../../../Services/TestDriverApi";
import { useHistory } from "react-router-dom";
import { useState } from "react";
import { toast, ToastContainer } from "react-toastify";
import LoadingBar from "react-top-loading-bar"

const api = new TestDriverApi();

export default function Remarcar (props) {

    const [idAgendamento, setIdAgendamento] = useState(props.location.state.IdAgendamento);
    const [idUsuario, setIdUsuario] = useState(props.location.state.IdUsuario);
    const [perfil, setPerfil] = useState(props.location.state.Perfil);

    const [data, setData] = useState(null);
    const [horario, setHorario] = useState("10:30");
    
    const history = useHistory();

    const voltar = () => {
        history.goBack();
    }

    const transformarEmHorarioCompleto = () => {
        const completo = `${data} ${horario}`;

        return completo;
    };

    const loadingBar = useRef(null);

    const remarcar = async () => {
        try {
            
            loadingBar.current.continuousStart();
            
            if(data === null)
                toast.error("A data é obrigatória");
            else{    
                const horarioCompleto = transformarEmHorarioCompleto();

                await api.remarcarAgendamento(horarioCompleto, idAgendamento);
                
                loadingBar.current.complete();
                
                history.goBack();
            }
        } catch (e) {
            loadingBar.current.complete();
            toast.error(e.response.data.mensagem);
        }
    }
    return(
        <ContainerTotal idUsuario={idUsuario} perfil={perfil}>
           <LoadingBar height={7} color="red" ref={loadingBar} /> 
           <ToastContainer/> 
            <div className="divContRemarcar">
                    <h2>Remarcar</h2>

                    <div className="divInputsRemarcar">
                        <label>Selecione a data
                            <input onChange={e => setData(e.target.value)} type="date" className="form-control"/>
                        </label>

                        <label>Selecione o horário
                            <input onChange={e => setHorario(e.target.value)} value={horario} type="time" className="form-control"/>
                        </label>
                    </div>

                    <div className="divBtnsRemarcar">
                        <button onClick={voltar} className="btn btn-danger">Cancelar</button>
                        <button onClick={remarcar} className="btn btn-success">Alterar</button>
                    </div>

            </div>
        </ContainerTotal>
    )
}