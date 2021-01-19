import React, {useEffect, useState, useRef} from 'react';
import ContainerTotal from '../../../Components/ContainerTotalLogado';
import Accordion from '../../../Components/Accordion';
import TestDriverApi from "../../../Services/TestDriverApi";
import "./Styles.css";
import { Link } from 'react-router-dom';
import { ToastContainer, toast } from "react-toastify";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriverApi();

export default function AgendadosFuncionario (props) {

    const [naoTemAgendamento, setNaoTemAgendamento] = useState(false);
    const [pendentes, setPendentes] = useState([]);
    const [idUsuario] = useState(props.location.state.idUsuario);
    const [perfil] = useState(props.location.state.perfil);

    const loadingBar = useRef(null);

    const retornarPendentes = async () => 
    {
        try {
        
          loadingBar.current.continuousStart();

          const resp = await api.esperandoAprovacao();
          setPendentes(resp);

          if(resp.length == 0)
            setNaoTemAgendamento(true);

          loadingBar.current.complete();
        } catch (e) {
          
          setNaoTemAgendamento(true);
          loadingBar.current.complete();
          toast.error(e.response.data.mensagem)
        
        }
    }

    const aceitarAgendamento = async (idAgendamento) => 
    {
        try {
          
          loadingBar.current.continuousStart();

          await api.aceitarAgendamento(idUsuario, idAgendamento);
          toast.success("Agendado com sucesso");

          loadingBar.current.complete();
          
          retornarPendentes();

        } catch (e) {

          loadingBar.current.complete();
          toast.error(e.response.data.mensagem)
        
        }
    }

      useEffect(() => {
        retornarPendentes();
      }, []);
    return (
      <ContainerTotal idUsuario={idUsuario} perfil="Funcionario">
        <LoadingBar height={7} color="red" ref={loadingBar} />
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
                <div>Cliente: {x.cliente}</div>
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

        { naoTemAgendamento === true &&
        <div className="naoTemAgendamento">
            <h1>Não há agendamentos para serem aprovados</h1>
        </div>
        }
      </ContainerTotal>
    );
}