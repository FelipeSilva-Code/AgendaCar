import React, { useState, useEffect, useRef } from "react";
import "./Styles.css";
import AccordionTeste from "../../../Components/Accordion";
import ContainerTotal from "../../../Components/ContainerTotalLogado";
import TestDriverApi from "../../../Services/TestDriverApi";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriverApi();

export default function AgendadosFuncionario(props) {
  const loadingBar = useRef(null);


  const [showAtribuidos, setShowAtribuidos] = useState(true);

  const [showConcluidos, setShowConcluidos] = useState(false);

  const [showOutros, setShowOutros] = useState(false);

  const [agendados, setAgendados] = useState([]);

  const [hoje, setHoje] = useState([]);

  const [amanha, setAmanha] = useState([]);

  const [depois, setDepois] = useState([]);

  const [concluidos, setConcluidos] = useState([]);

  const [outros, setOutros] = useState([]);

  const [idUsuario] = useState(props.location.state.idUsuario);

  const [perfil] = useState(props.location.state.perfil);

  const [situacao, setSituacao] = useState("Concluido");

  //Funções Que Chamam a API
  const agendadosClick = async () => {
    try {
      const resp = await api.agendadosDoFuncionario(idUsuario);

      loadingBar.current.continuousStart();

      setAgendados(resp);
      setHoje(resp.hoje);
      setAmanha(resp.amanha);
      setDepois(resp.depois);
      setConcluidos(resp.concluidos);
      setOutros(resp.outros);

      loadingBar.current.complete();
    } catch (e) {
      toast.error(e.response.data.messagem);
      console.log(e.response)
    }
  };

  const mudarSituacaoClick = async (idAgendamento) => {

      try {

            await api.mudarSituacao(idAgendamento, situacao);

            agendadosClick()

      } catch (e) {
          toast.error(e.response.data.mensagem);
      }
  }

  const cancelarClick = async (idAgendamento) => {
      try {

        await api.mudarSituacao(idAgendamento, "Cancelado");

        agendadosClick();

      } catch (e) {
        
        toast.error(e.response.data.mensagem);

      }
  }


  //Outros
  const mostrarAlgum = (oqueMostrar) => {
    if (oqueMostrar === "Concluidos") {
      setShowAtribuidos(false);
      setShowOutros(false);
      setShowConcluidos(true);
      if (concluidos.length === 0) toast.error("Nenhum agendamento concluido");
    } else if (oqueMostrar === "Atribuidos") {
      setShowAtribuidos(true);
      setShowOutros(false);
      setShowConcluidos(false);
      if (hoje.length === 0 && amanha.length === 0 && depois.length === 0)
        toast.error("Nenhum agendamento atribuido");
    } else if (oqueMostrar === "Outros") {
      setShowAtribuidos(false);
      setShowOutros(true);
      setShowConcluidos(false);
      if (outros.length === 0) toast.error("Nenhum agendamento");
    }
  };

  useEffect(() => {
    agendadosClick();
  }, []);

  return (
    <div>
      <ContainerTotal>
        <LoadingBar height={7} color="red" ref={loadingBar} />

        <div className="title">
          <h1>Agendamentos</h1>
          <span onClick={() => mostrarAlgum("Atribuidos")}>Atribuídos</span> |
          <span onClick={() => mostrarAlgum("Concluidos")}> Concluídos </span> |
          <span onClick={() => mostrarAlgum("Outros")}> Outros </span>
        </div>

        {showAtribuidos === true && (
          <div>
            <div className="dicAccordionSpace">
              {hoje.length !== 0 && (
                <div>
                  <h4>Hoje</h4>
                  {hoje.map((x) => (
                    <AccordionTeste
                      Titulo={
                        <div>
                          <h5>
                            {x.marca} {x.modelo} -{" "}
                            {new Date(x.data).toLocaleString()}
                          </h5>
                        </div>
                      }
                      Conteudo={
                        <div>
                          <div>Funcionário: {x.funcionario}</div>
                          <div>Situação: {x.situacao}</div>
                          <div className="divsec">
                            Alterar&nbsp;Situação:
                            <select
                              onChange={(e) => setSituacao(e.target.value)}
                              className="form-control selectFuncionario"
                            >
                              <option>Concluído</option>
                              <option>Não Compareceu</option>
                              <option>Cancelado</option>
                            </select>
                          </div>
                          <button
                            onClick={() => mudarSituacaoClick(x.idAgendamento)}
                            type="button"
                            className="btn btn-outline-success"
                          >
                            Salvar
                          </button>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>

            <div className="dicAccordionSpace">
              {amanha.length !== 0 && (
                <div>
                  <h4>Amanhã</h4>
                  {amanha.map((x) => (
                    <AccordionTeste
                      Titulo={
                        <div>
                          <h5>
                            {x.marca} {x.modelo} -{" "}
                            {new Date(x.data).toLocaleString()}
                          </h5>
                        </div>
                      }
                      Conteudo={
                        <div>
                          <div>
                            <div>Funcionário: {x.funcionario}</div>
                            <div>Situação: {x.situacao}</div>
                          </div>
                          <button
                            onClick={() => cancelarClick(x.idAgendamento)}
                            type="button"
                            className="btn btn-outline-danger"
                          >
                            Cancelar Test Drive
                          </button>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>

            <div className="dicAccordionSpace">
              {depois.length !== 0 && (
                <div>
                  <h4>Depois</h4>
                  {depois.map((x) => (
                    <AccordionTeste
                      Titulo={
                        <div>
                          <h5>
                            {x.marca} {x.modelo} -{" "}
                            {new Date(x.data).toLocaleString()}
                          </h5>
                        </div>
                      }
                      Conteudo={
                        <div>
                          <div>
                            <div>Funcionário: {x.funcionario}</div>
                            <div>Situação: {x.situacao}</div>
                          </div>
                          <button
                            onClick={() =>cancelarClick(x.idAgendamento)}
                            type="button"
                            className="btn btn-outline-danger"
                          >
                            Cancelar Test Drive
                          </button>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        )}

        {showConcluidos === true && (
          <div>
            <div className="dicAccordionSpace">
              {concluidos.length !== 0 && (
                <div>
                  <h4>Concluidos</h4>
                  {concluidos.map((x) => (
                    <AccordionTeste
                      Titulo={
                        <div>
                          <h5>
                            {x.marca} {x.modelo} -{" "}
                            {new Date(x.data).toLocaleString()}
                          </h5>
                        </div>
                      }
                      Conteudo={
                        <div>
                          <div>Funcionário: {x.funcionario}</div>
                          <div>Situação: {x.situacao}</div>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        )}

        {showOutros === true && (
          <div>
            <div className="dicAccordionSpace">
              {outros.length !== 0 && (
                <div>
                  <h4>Outros</h4>
                  {outros.map((x) => (
                    <AccordionTeste
                      Titulo={
                        <div>
                          <h5>
                            {x.marca} {x.modelo} -{" "}
                            {new Date(x.data).toLocaleString()}
                          </h5>
                        </div>
                      }
                      Conteudo={
                        <div>
                          <div>Funcionário: {x.funcionario}</div>
                          <div>Situação: {x.situacao}</div>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        )}
      </ContainerTotal>

      <ToastContainer />
    </div>
  );
}
