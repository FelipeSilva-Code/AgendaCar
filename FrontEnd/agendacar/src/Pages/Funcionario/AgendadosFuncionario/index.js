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

  const [qualMostrar, setQualMostrar] = useState("Atribuidos")

  const [agendados, setAgendados] = useState([]);

  const [hoje, setHoje] = useState([]);
  const [amanha, setAmanha] = useState([]);
  const [depois, setDepois] = useState([]);
  const [concluidos, setConcluidos] = useState([]);
  const [outros, setOutros] = useState([]);

  const [idUsuario] = useState(props.location.state.idUsuario);
  const [perfil] = useState(props.location.state.perfil);
  const [situacao, setSituacao] = useState("Concluido");


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
      loadingBar.current.complete();
      toast.error(e.response.data.messagem);
    }
  };

  const mudarSituacaoClick = async (idAgendamento) => {

      try {

          loadingBar.current.continuousStart();
          
          await api.mudarSituacao(idAgendamento, situacao);

          loadingBar.current.complete();

          agendadosClick()

      } catch (e) {

          loadingBar.current.complete();
          toast.error(e.response.data.mensagem);
      }
  }

  const cancelarClick = async (idAgendamento) => {
      try {

        loadingBar.current.continuousStart();

        await api.mudarSituacao(idAgendamento, "Cancelado");

        loadingBar.current.complete();

        agendadosClick();

      } catch (e) {

        loadingBar.current.complete();
        toast.error(e.response.data.mensagem);

      }
  }


  const mostrarAlgum = (oqueMostrar) => {
    setQualMostrar(oqueMostrar)
  };

  useEffect(() => {
    agendadosClick();
  }, []);

  return (
    <div>
      <ContainerTotal idUsuario={idUsuario} perfil="Funcionario">
        <LoadingBar height={7} color="red" ref={loadingBar} />

        <div className="title">
          <h1>Agendamentos</h1>
          <span onClick={() => mostrarAlgum("Atribuidos")}>Atribuídos</span> |
          <span onClick={() => mostrarAlgum("Concluidos")}> Concluídos </span> |
          <span onClick={() => mostrarAlgum("Outros")}> Outros </span>
        </div>

        {qualMostrar === "Atribuidos" && (
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
                          <div>Cliente: {x.cliente}</div>
                          <div>Situação: {x.situacao}</div>
                          <div className="divsec">
                            Alterar&nbsp;Situação:
                            <select
                              onChange={(e) => setSituacao(e.target.value)}
                              className="form-control selectFuncionario"
                            >
                              <option>Concluido</option>
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
          </div>
        )}

        {qualMostrar === "Concluidos" && (
          <div>
            <div className="dicAccordionSpace">
              {concluidos.length !== 0 && (
                <div>
                  <h4>Concluídos</h4>
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
                          <div>Nota: {x.nota === 0 ?"O cliente ainda não avaliou" :x.nota}</div>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        )}

        {qualMostrar === "Outros" && (
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
