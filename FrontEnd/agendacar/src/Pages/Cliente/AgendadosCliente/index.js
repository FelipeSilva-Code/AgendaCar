import React, { useState, useEffect, useRef } from 'react';
import './Styles.css';
import AccordionTeste from '../../../Components/Accordion'
import ContainerTotal from '../../../Components/ContainerTotalLogado';
import TestDriverApi from '../../../Services/TestDriverApi';
import AvaliarTestDrive from '../../../Components/AvaliarTestDrive';
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import LoadingBar from "react-top-loading-bar";
import { Link, useHistory } from 'react-router-dom';

const api = new TestDriverApi();

export default function AgendadosCliente (props) {

  const loadingBar = useRef(null);
  const [showAvaliar, setShowAvaliar] = useState(false);
  const [qualMostrar, setQualMostrar] = useState("Atribuídos")
  
  const [agendados, setAgendados] = useState([]);
  const [hoje, setHoje] = useState([]);
  const [amanha, setAmanha] = useState([]);
  const [depois, setDepois] = useState([]);
  const [concluidos, setConcluidos] = useState([])
  const [outros, setOutros] = useState([]);


  const [responseLogado, setResponseLogado] = useState(props.location.state);
  const [idUsuario] = useState(props.location.state.idUsuario)
  const [perfil] = useState(props.location.state.perfil)
  const [id, setId] = useState(0);
  const [nota, setNota] = useState(0);
  
  //Funções Que Chamam a API
   const agendadosClick = async () => {
 
        try {

          const resp = await api.agendadosDoCliente(idUsuario);

         
          loadingBar.current.continuousStart();

          setAgendados(resp)
          setHoje(resp.hoje);
          setAmanha(resp.amanha);
          setDepois(resp.depois);
          setConcluidos(resp.concluidos);
          setOutros(resp.outros);

          console.log(resp);

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

          await api.avaliarTestDrive(id, req);

          toast.success("Avaliado com sucesso!!!");

          loadingBar.current.complete();

          agendadosClick();

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

   
   //Funções Que Transformam os Dados


     const mudarCorAoClicar = (posicao, notaEstrela) => {
       const list = document.getElementsByTagName("ul")[0];  
       for(let i = 0; i <= posicao; i++)
        {
          const x = list.getElementsByTagName("li")[i];
          const f = x.getElementsByTagName("i")[0];
          f.style.color="#ffd900"
        }
        
        for(let a = 4; a > posicao; a--)
        {
            const x = list.getElementsByTagName("li")[a];
            const f = x.getElementsByTagName("i")[0];
            f.style.color="rgb(199, 169, 0)"
        }     

        setNota(notaEstrela);
    }

    const oQueMostrar = (oquemostrar) => {
      setQualMostrar(oquemostrar)
    }

    const history = useHistory();

    const irParaATelaDeRemarcar = (idAgendamento) => {
      history.push({pathname:"/remarcar", state:{
        "IdUsuario": idUsuario,
        "IdAgendamento": idAgendamento,
        "Perfil": perfil
      }});
    }
    

   useEffect(() => {
     agendadosClick();
   }, []);
  

  return (
    <div>
      <ContainerTotal
         idUsuario={idUsuario}
         perfil="Cliente">

        <LoadingBar height={7} color="red" ref={loadingBar} />

        <div className="title">
          <h1>Agendamentos</h1>
         
          <span onClick={() => oQueMostrar("Atribuídos")}>Atribuídos</span> |
          <span onClick={() => oQueMostrar("Concluídos")}> Concluídos </span> |
          <span onClick={() => oQueMostrar("Outros")}> Outros </span>
        
        </div>

        {qualMostrar === "Atribuídos" && 
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
                            {x.marca} {x.modelo} -
                            {new Date(x.data).toLocaleString()}
                          </h5>
                        </div>
                      }
                      Conteudo={
                        <div>
                          <div>Funcionário: {x.funcionario}</div>
                          <div>Situação: {x.situacao}</div>
                          <button onClick={() => irParaATelaDeRemarcar(x.idAgendamento)} className="btn btn-outline-danger">Remarcar</button>
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
                          <button onClick={() => irParaATelaDeRemarcar(x.idAgendamento)} className="btn btn-outline-danger">Remarcar</button>
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
                          <button onClick={() => irParaATelaDeRemarcar(x.idAgendamento)} className="btn btn-outline-danger">Remarcar</button>
                        </div>
                      }
                    ></AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        }

        {qualMostrar === "Concluídos" && 
          <div>
            <div className="dicAccordionSpace">
              {concluidos.length !== 0 && (
                <div>
                  <h4>Concluídos</h4>
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
                              
                              {x.nota === 0 &&
                                <button
                                  onClick={() =>
                                    mostrarAvaliarClick(x.idAgendamento)
                                  }
                                  type="button"
                                  className="btn btn-outline-success"
                                >
                                  Avaliar Test Drive
                                </button>
                              }
                       
                            </div>
                            }>
                            
                    </AccordionTeste>
                  ))}
                </div>
              )}
            </div>
          </div>
        }

        {qualMostrar === "Outros" && 
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
        }

        {showAvaliar === true && (
          <AvaliarTestDrive>
            <div className="avaliarTitle">
              <h4>Qual a sua avaliação do Test Drive?</h4>
            </div>

            <div className="darNotaAvaliacao">
              <div className="stars">
                  <ul>
                  <li type="none"><i id="star1"  onClick={() => mudarCorAoClicar(0, 1)} class="far fa-star"></i></li>
                  <li type="none"><i id="star2"  onClick={() => mudarCorAoClicar(1, 2)} class="far fa-star"></i></li>
                  <li type="none"><i id="star3"  onClick={() => mudarCorAoClicar(2, 3)} class="far fa-star"></i></li>
                  <li type="none"><i id="star4"  onClick={() => mudarCorAoClicar(3, 4)} class="far fa-star"></i></li>
                  <li type="none"><i id="star5"  onClick={() => mudarCorAoClicar(4, 5)} class="far fa-star"></i></li>
                  </ul>
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