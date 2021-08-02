import React from "react";
import "./styles.css"
import { useState } from "react";
import { Link } from "react-router-dom";
import ContainerTotal from "../../../Components/ContainerTotalLogado";
import TestDriveApi from "../../../Services/TestDriverApi";
import { toast, ToastContainer } from "react-toastify";
import { useEffect, useRef } from "react";
import LoadingBar from "react-top-loading-bar";

const api = new TestDriveApi();

export default function ListarCarros(props) {
  const [carrosListados, setCarrosListados] = useState([]);

  const [idUsuario, setIdUsuario] = useState(props.location.state.idUsuario)

  const loadingBar = useRef(null);
  
  const buscarCarro = async (busca) => {
    try {

        if(busca == undefined)
            busca = "";
        
            loadingBar.current.continuousStart();

            const resp = await api.buscarCarro(busca);
        
            setCarrosListados(resp);

            loadingBar.current.complete();
    } catch (e) {

            loadingBar.current.complete();
            toast.error(e.response.data);
            setCarrosListados([]);
    
        }
  };

  const excluirCarro = async (idCarro) => {
      try {

        const x = window.confirm("Você irá excluir um carro do sistema.")
        
        if(x === true){

          loadingBar.current.continuousStart();
          await api.deletarCarro(idCarro);
          buscarCarro("");
          loadingBar.current.complete();

        }
          
      } catch (e) {

        loadingBar.current.complete();
        toast.error(e.response.data.mensagem);
      
      }
  }

   useEffect(() => {
     buscarCarro("");
   }, []);

  return (
    <ContainerTotal idUsuario={idUsuario} perfil="Funcionario">
      <LoadingBar height={7} color="red" ref={loadingBar} />
      <ToastContainer/>
      <h3>Todos os Carros Cadastrados</h3>

      <div className="procurarCarros">
        <label>
          Procurar carros:
          <input placeholder="insira a marca, modelo ou cor do carro" onChange={(e) => buscarCarro(e.target.value)} type="search" className="form-control" />
        </label>
      </div>

      {carrosListados.map((item) => (
        <div className="infoCarro">
          <h4>
            {item.marca} {item.modelo} - {item.cor} - Qtd. Disponível: {item.qtdDisponivel} 
          </h4>
           
          <div className="ladoDireitoCarroListado">
            <button onClick={() => excluirCarro(item.id)} className="btn btn-outline-danger">Excluir Carro</button>
            <Link to={{pathname:"/Funcionario/VerInfoCarro", state:item.id}}>Ver Mais / Alterar Info </Link>
          </div>
        </div>
      ))}
    </ContainerTotal>
  );
}
