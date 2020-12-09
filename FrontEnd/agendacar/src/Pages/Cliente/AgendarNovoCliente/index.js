import React from 'react';
import './style.css';
import ContainerTotal from '../../../Components/ContainerTotal';
import TestDriverApi from '../../../Services/TestDriverApi'
import { useState } from 'react';
import { useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import { toast, ToastContainer } from 'react-toastify';

const api = new TestDriverApi();

export default function AgendarNovoCliente (props) {

    const [todosOsCarros, setTodosOsCarros] = useState([]);
    const [carrosSeparadosPelaMarca, setCarrosSeparadosPelaMarca] = useState([]);
    const [carroSeparadoPeloModelo, setCarroSeparadoPeloModelo] = useState({});
    const [idUsuario] = useState(props.location.state.idUsuario);
    const [perfil] = useState(props.location.state.perfil);
    const [data, setData] = useState();
    const [hora, setHora] = useState();
    const [idCarro, setIdCarro] = useState(0);

    const history = useHistory();

    const listarTodosOsCarros = async () => {
     const resp = await api.listarTodosOsCarros();
     setTodosOsCarros([...resp]);

    }

    const validarHorario = () => {
      if(data === undefined){
         toast.error("A data é obrigatória");
         return false;
      }
      else if(hora === undefined){
        toast.error("A hora é obrigatória"); 
        return false;
      }
      else
        return true;
    }

    const settarTodosOsEstados = (set) => {
      
      console.log(set);

      if (set === "Marca") {
        setCarrosSeparadosPelaMarca([]);
        carroSeparadoPeloModelo.cor = "";
        carroSeparadoPeloModelo.anoFabricacao = "";
        carroSeparadoPeloModelo.anoModelo = "";
        carroSeparadoPeloModelo.idCarro = 0;
        carroSeparadoPeloModelo.marca = "";
        carroSeparadoPeloModelo.modelo = "";
        carroSeparadoPeloModelo.id = 0;
        setIdCarro(0);

      }else{
        carroSeparadoPeloModelo.cor = "";
        carroSeparadoPeloModelo.anoFabricacao = "";
        carroSeparadoPeloModelo.anoModelo = "";
        carroSeparadoPeloModelo.idCarro = 0;
        carroSeparadoPeloModelo.marca = "";
        carroSeparadoPeloModelo.modelo = "";
        carroSeparadoPeloModelo.id = 0;
        setIdCarro(0)
       
      }

    }

    const listarCarrosPelaMarca = async (marca) => {

      if(marca == "nao passou")
        settarTodosOsEstados("Marca");
      else{
      const resp = await api.listarCarrosPelaMarca(marca);
     
      setCarrosSeparadosPelaMarca([...resp]);
      }


    }

    const retornarCarroPeloModelo = async (modelo) => {
      if(modelo == "nao passou")
        settarTodosOsEstados("Modelo");
      else{   
        const resp = await api.voltarCarroPeloModelo(modelo);

        setCarroSeparadoPeloModelo(resp);

        setIdCarro(resp.id);
      }
    }

    const transformarEmHorarioCompleto = () => {
      const horario = `${data} ${hora}`;

      return horario
    }


     const agendarConsulta = async () => {
      try {

        const horarioCorreto = validarHorario();

        if(horarioCorreto){

        const horario = transformarEmHorarioCompleto();

        console.log(horario);
       
        const req = {
          "idCliente": idUsuario,
          "idCarro": idCarro,
          "data": horario
        };

        await api.agendarTestCliente(req);

        toast.success("Test Drive agendado com sucesso!");

        settarTodosOsEstados("Marca");

        listarTodosOsCarros();
      
      }

      } catch (e) {
        toast.error(e.response.data.mensagem);

      }
    }

    const voltar = () => {
        history.goBack();
    }

    useEffect(() => {
      listarTodosOsCarros();
    }, []);
  
    
    return (
      <>
       {todosOsCarros.length === 0 &&
        <div className="semCarrosDisponiveis">
          <h1>Não há Carros Disponíveis Para Test Drive</h1>
          <button onClick={voltar} className="btn btn-danger">&nbsp; &nbsp; Voltar &nbsp; &nbsp;</button>
        </div>
        }
      <ContainerTotal>
        
        <ToastContainer/>

       
        <div className="conteinerCentralAgendar">
          <h2 className="title">Faça seu Agendamento </h2>

          <div className="containerDadosCarro">
            <h4>Escolha o Carro</h4>
           
            <div className="divInput1">
              <label>
                Marca do carro
                <select
                  onChange={(e) => listarCarrosPelaMarca(e.target.value)}
                  class="form-control"
                >
                  <option value="nao passou"></option>
                  {todosOsCarros.map((x) => (
                    <option> {x.marca} </option>
                  ))}
                </select>
              </label>

              <label>
                Modelo do carro
                <select
                  onChange={(e) => retornarCarroPeloModelo(e.target.value)}
                  class="form-control"
                >
                  <option value="nao passou"></option>
                  {carrosSeparadosPelaMarca.map((x) => (
                    <option>{x.modelo}</option>
                  ))}
                </select>
              </label>
            </div>

            <div className="divInput1">
              <label>
                Ano Fabricação
                <input
                  value={carroSeparadoPeloModelo.anoFabricacao}
                  class="form-control"
                  readOnly
                ></input>
              </label>

              <label>
                Ano Versão
                <input
                  value={carroSeparadoPeloModelo.anoModelo}
                  class="form-control"
                  readOnly
                ></input>
              </label>
            </div>


            <div className="divInput1">
              <label>
                Cor
                <input
                  value={carroSeparadoPeloModelo.cor}
                  class="cor form-control"
                  readOnly
                />
              </label>
            </div>
          </div>

          <div className="containerDadosHorario">
            <h4>Escolha o horário</h4>

            <div className="divInput1">
              <label>
                Data
                <input onChange={e => setData(e.target.value)} className="form-control" type="date" />
              </label>

              <label>
                Hora
                <input onChange={e => setHora(e.target.value)} className="form-control" type="time" />
              </label>
            </div>
          </div>

          <div className="divInput1">
            <button onClick={voltar} className="btn btn-danger">Cancelar</button>
            <button onClick={agendarConsulta} className="btn btn-success">Agendar</button>
          </div>
        </div>
      </ContainerTotal>
      </>
    );
}