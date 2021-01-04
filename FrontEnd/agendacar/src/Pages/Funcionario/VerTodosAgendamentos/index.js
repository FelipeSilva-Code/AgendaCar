import React from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotal";
import AccordionTeste from "../../../Components/Accordion";
import { useState } from "react";
import TestDriveApi from "../../../Services/TestDriverApi"
import { toast, ToastContainer } from "react-toastify";
import { useEffect } from "react";

const api = new TestDriveApi();

export default function VerTodosOsAgendamentos () {

    const [qualMostrar, setQualMostrar] = useState("Atribuídos")

    const [agendados, setAgendados] = useState([]);

    const [hoje, setHoje] = useState([]);

    const [amanha, setAmanha] = useState([]);

    const [depois, setDepois] = useState([]);

    const [concluidos, setConcluidos] = useState([]);

    const [outros, setOutros] = useState([]);

    const qualMostrarClick = (qualIra) => {
        setQualMostrar(qualIra)
    }

    const pegarAgendamentos = async () => {
        try {
            
            const resp = await api.pegarTodosOsAgendamentos();
            setAgendados(resp);
            setHoje(resp.hoje);
            setAmanha(resp.amanha);
            setDepois(resp.depois);
            setConcluidos(resp.concluidos);
            setOutros(resp.outros);

        } catch (e) {
            
            toast.error(e.response.data.mensagem)

        }
    }

    useEffect(() => {
      pegarAgendamentos();
    }, []);


    return (
      <ContainerTotal>
          <ToastContainer/>
        <h4>Ver Todos Os Agendamentos</h4>

        <h6 className="title"> <span onClick={() => qualMostrarClick("Atribuídos")}> Atribuídos </span> | <span onClick={() => qualMostrarClick("Concluídos")}> Concluídos </span> | <span onClick={() => qualMostrarClick("Outros")}> Outros </span></h6>

        {qualMostrar === "Atribuídos" && (
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
                          <div>Funcionário: {x.funcionario}</div>
                          <div>Situação: {x.situacao}</div>
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
                            <div>Cliente: {x.cliente} </div>
                            <div>Funcionário: {x.funcionario}</div>
                            <div>Situação: {x.situacao}</div>
                          </div>
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
                            <div>Cliente: {x.cliente} </div>
                            <div>Funcionário: {x.funcionario}</div>
                            <div>Situação: {x.situacao}</div>
                          </div>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        )}

        {qualMostrar === "Concluídos" && (
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
                          <div>Cliente: {x.cliente} </div>
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
                          <div>Cliente: {x.cliente} </div>
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
    );
}