import React, { useState, useEffect, useRef } from 'react';
import './Styles.css';
import AccordionTeste from '../../../Components/Accordion'
import ContainerTotal from '../../../Components/ContainerTotal';
import TestDriverApi from '../../../Services/TestDriverApi';
import AvaliarTestDrive from '../../../Components/AvaliarTestDrive';
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriverApi();

export default function AgendadosCliente (props) {

  const loadingBar = useRef(null);

  const [showAvaliar, setShowAvaliar] = useState(false);

  const [showAtribuidos, setShowAtribuidos] = useState(true)
  
  const [showConcluidos, setShowConcluidos] = useState(false);
  
  const [showOutros, setShowOutros] = useState(false);

  const [agendados, setAgendados] = useState([]);

  const [hoje, setHoje] = useState([]);

  const [amanha, setAmanha] = useState([]);

  const [depois, setDepois] = useState([]);

  const [concluidos, setConcluidos] = useState([])

  const [outros, setOutros] = useState([]);

  const [idUsuario] = useState(props.location.state.idUsuario)

  const [perfil] = useState(props.location.state.perfil)

  const [id, setId] = useState(0);

  const [nota, setNota] = useState(0);
  
  //Funções Que Chamam a API
   const agendadosClick = async () => {
 
        try {

          const resp = await api.agendadosDoCliente(idUsuario);

          console.log(resp);

          loadingBar.current.continuousStart();

          setAgendados(resp)
          setHoje(resp.hoje);
          setAmanha(resp.amanha);
          setDepois(resp.depois);
          setConcluidos(resp.concluidos);
          setOutros(resp.outros);


          loadingBar.current.complete();

        } catch (e) {
          toast.error(e.response.data.messagem);
          console.log(e.response.data.messagem);
        }
        
    };

    const avaliarTestDrive = async () => {
      try {
        if (nota !== 0) {
          const req = {
            nota,
          };
          
          loadingBar.current.continuousStart();

          console.log(nota);

          const resp = await api.avaliarTestDrive(id, req);

          toast.success("Avaliado com sucesso!!!");

          loadingBar.current.complete();

          cancelarMostrarAvaliarClick();
        } else toast.error("A nota é obrigatória!!!");
      } catch (error) {
        console.log(error);
      }
    };



  //Funções Que Alteram a Redenrização
   const mostrarAvaliarClick = (id) => {
     setShowAvaliar(true);
     setId(id);
   };

   const cancelarMostrarAvaliarClick = () => {
     setId(0);
     setNota(0);
     setShowAvaliar(false);
   };

   const mostrarAlgum = (oqueMostrar) => {
     if (oqueMostrar === "Concluidos") {
       setShowAtribuidos(false);
       setShowOutros(false);
       setShowConcluidos(true);
       if(concluidos.length === 0)
         toast.error("Nenhum agendamento concluido")
     } else if (oqueMostrar === "Atribuidos") {
       setShowAtribuidos(true);
       setShowOutros(false);
       setShowConcluidos(false);
        if(hoje.length === 0 && amanha.length === 0 && depois.length === 0)
           toast.error("Nenhum agendamento atribuido")
     } else if (oqueMostrar === "Outros") {
       setShowAtribuidos(false);
       setShowOutros(true);
       setShowConcluidos(false);
         if(outros.length === 0)
            toast.error("Nenhum agendamento")
     }
   };


   
   //Funções Que Transformam os Dados


    const alterarNota = (avaliacao) => {
         setNota(avaliacao);
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
          <span onClick={() => mostrarAlgum("Atribuidos")}>Atribuidos</span> |
          <span onClick={() => mostrarAlgum("Concluidos")}> Concluidos </span> |
          <span onClick={() => mostrarAlgum("Outros")}> Outros </span>
        </div>

        {agendados.length === 0 && (
          <div className="noTestsDrivers">
            <div>
              <h2>Você não tem tests drives agendados!!!</h2>
              <h5>Gostaria de Agendar? Sim</h5>
            </div>
          </div>
        )}

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

        {showConcluidos === true && (
          <div>
            <div className="dicAccordionSpace">
              {concluidos.length !== 0 && (
                <div>
                  <h4>Concluidos</h4>
                  {concluidos.map((x) => (
                   <AccordionTeste
                      Titulo = {
                        <div>
                            <h5>
                              {x.marca} {x.modelo} -{" "}
                              {new Date(x.data).toLocaleString()}
                            </h5>
                        </div>
                      }
                      Conteudo = {
                        <div>
                       
                             <div>Funcionário: {x.funcionario}</div>
                             <div>Situação: {x.situacao}</div>
                        
                              <button
                                onClick={() =>
                                  mostrarAvaliarClick(x.idAgendamento)
                                }
                                type="button"
                                className="btn btn-outline-success"
                              >
                                Avaliar Test Drive
                              </button>
                       
                            </div>
                            }>
                            
                    </AccordionTeste>
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

        {showAvaliar === true && (
          <AvaliarTestDrive>
            <div className="avaliarTitle">
              <h4>Qual a sua avaliação do Test Drive?</h4>
            </div>

            <div className="darNotaAvaliacao">
              <div className="stars">
                <button onClick={() => alterarNota(5)} className="btnDarNota">
                  <i class="fas fa-star"></i>
                </button>
                <button onClick={() => alterarNota(4)} className="btnDarNota">
                  <i class="fas fa-star"></i>
                </button>
                <button onClick={() => alterarNota(3)} className="btnDarNota">
                  <i class="fas fa-star"></i>
                </button>
                <button onClick={() => alterarNota(2)} className="btnDarNota">
                  <i class="fas fa-star"></i>
                </button>
                <button onClick={() => alterarNota(1)} className="btnDarNota">
                  <i class="fas fa-star"></i>
                </button>
              </div>
              <div className="notas">
                <h4>5</h4>
                <h4>4</h4>
                <h4>3</h4>
                <h4>2</h4>
                <h4>1</h4>
              </div>
            </div>

            <div className="containerBtns">
              <button
                onClick={cancelarMostrarAvaliarClick}
                type="button"
                class="btn btn-danger"
              >
                Cancelar
              </button>

              <button
                onClick={() => avaliarTestDrive()}
                type="button"
                class="btn btn-success"
              >
                Concluir
              </button>
            </div>
          </AvaliarTestDrive>
        )}
      </ContainerTotal>

      <ToastContainer />
    </div>
  );
}