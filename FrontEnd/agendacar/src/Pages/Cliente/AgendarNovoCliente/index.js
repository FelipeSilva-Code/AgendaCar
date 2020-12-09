import React from 'react';
import './style.css';
import ContainerTotal from '../../../Components/ContainerTotal';
import TestDriverApi from '../../../Services/TestDriverApi'
import { useState } from 'react';
import { useEffect } from 'react';
import { set } from 'date-fns';

const api = new TestDriverApi();

export default function AgendarNovoCliente (props) {

    const [todosOsCarros, setTodosOsCarros] = useState([]);
    const [carrosSeparadosPelaMarca, setCarrosSeparadosPelaMarca] = useState([]);
    const [carroSeparadoPeloModelo, setCarroSeparadoPeloModelo] = useState({});
    const [idUsuario] = useState(props.location.state.idUsuario);
    const [perfil] = useState(props.location.state.perfil);

    const listarTodosOsCarros = async () => {
     const resp = await api.listarTodosOsCarros();
     setTodosOsCarros([...resp]);

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
        console.log("fff")
      }else{
        carroSeparadoPeloModelo.cor = "";
        carroSeparadoPeloModelo.anoFabricacao = "";
        carroSeparadoPeloModelo.anoModelo = "";
        carroSeparadoPeloModelo.idCarro = 0;
        carroSeparadoPeloModelo.marca = "";
        carroSeparadoPeloModelo.modelo = "";
        carroSeparadoPeloModelo.id = 0;
        console.log("xxx");

        console.log(carroSeparadoPeloModelo.anoModelo)
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
      }
    }

    useEffect(() => {
      listarTodosOsCarros();
    }, []);
  
    
    return (
      <ContainerTotal>
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

            <p>{carroSeparadoPeloModelo.anoModelo}</p>

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
                <input className="form-control" type="date" />
              </label>

              <label>
                Hora
                <input className="form-control" type="time" />
              </label>
            </div>
          </div>

          <div className="divInput1">
            <button className="btn btn-danger">Cancelar</button>
            <button className="btn btn-success">Agendar</button>
          </div>
        </div>
      </ContainerTotal>
    );
}