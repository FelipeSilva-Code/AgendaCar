import React, {useEffect, useState} from 'react';
import ContainerTotal from '../../../Components/ContainerTotal';
import Accordion from '../../../Components/Accordion';
import TestDriverApi from "../../../Services/TestDriverApi";
import "./Styles.css";
import { Link } from 'react-router-dom';
import { ToastContainer, toast } from "react-toastify";

const api = new TestDriverApi();

export default function AgendadosFuncionario (props) {

    const [pendentes, setPendentes] = useState([]);
    const [idUsuario] = useState(props.location.state.idUsuario);
    const [perfil] = useState(props.location.state.perfil);

    const retornarPendentes = async () => 
    {
        const resp = await api.esperandoAprovacao();

        setPendentes(resp)
    
        console.log(resp);
        console.log(pendentes);
    }

    const aceitarAgendamento = async (idAgendamento) => 
    {
        try {
          const resp = await api.aceitarAgendamento(idUsuario, idAgendamento);
          console.log(resp);
          toast.success("Agendado com sucesso");

          retornarPendentes();

        } catch (e) {
          toast.error(e.response.data.menssagem)
          console.log(e.response.data.menssagem);
        }
    }

      useEffect(() => {
        retornarPendentes();
      }, []);
    return (
      <ContainerTotal>
        <ToastContainer/>
        <h2>Esperando Aprovação</h2>

        {pendentes.map(x => (
          <Accordion
            Titulo={
              <div>
                <h5>
                  {x.marca} {x.modelo} - {new Date(x.data).toLocaleString()}
                </h5>
              </div>
            }
            Conteudo={
              <div>
                <div>Funcionário: {x.funcionario}</div>
                <div>Situação: {x.situacao}</div>

                <button
                  onClick={() => aceitarAgendamento(x.idAgendamento)}
                  type="button"
                  className="btn btn-outline-success"
                >
                  Aprovar Test Drive
                </button>
              </div>
            }
          ></Accordion>

        ))}

        {pendentes.length === 0 &&
        <div className="naoTemAgendamento">
            <h1>Não há agendamentos para serem aprovados</h1>
        </div>
        }
      </ContainerTotal>
    );
}