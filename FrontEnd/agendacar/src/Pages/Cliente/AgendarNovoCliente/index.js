import React from 'react';
import './style.css';
import ContainerTotal from '../../../Components/ContainerTotal';
import TestDriverApi from '../../../Services/TestDriverApi'
import { useState } from 'react';
import { useEffect } from 'react';

const api = new TestDriverApi();

export default function AgendarNovoCliente (props) {

    const [todosOsCarros, setTodosOsCarros] = useState([]);
    const [carrosSeparadosPelaMarca, setCarrosSeparadosPelaMarca] = useState([]);
    const [carroSeparadoPeloModelo, setCarroSeparadoPeloModelo] = useState({

    });
    const [idUsuario] = useState(props.location.state.idUsuario);
    const [perfil] = useState(props.location.state.perfil);

    const listarTodosOsCarros = async () => {
     const resp = await api.listarTodosOsCarros();
     setTodosOsCarros([...resp]);

    }

    const listarCarrosPelaMarca = async (marca) => {
      const resp = await api.listarCarrosPelaMarca(marca);
      setCarrosSeparadosPelaMarca([...resp]);
    }

    const retornarCarroPeloModelo = async (modelo) => {
      const resp = await api.voltarCarroPeloModelo(modelo);
      setCarroSeparadoPeloModelo(resp);
      console.log(resp);
      console.log(carroSeparadoPeloModelo)
    }

    useEffect(() => {
      listarTodosOsCarros();
    }, []);
  
    
    return (
      <ContainerTotal>
        <div class="container">
          <a class="links" id="paracadastro"></a>
          <a class="links" id="paralogin"></a>

          <div class="content">
            <div className="cadas">
              <form method="post" action="">
                <h1 classNam="title">Faça seu Agendamento </h1>

                <div className="infocar">
                  <p>
                    <label for="marc_car" className="inf">
                      Marca do carro
                    </label>
                    <select
                      onChange={(e) => listarCarrosPelaMarca(e.target.value)}
                      id="marc_car"
                      name="marc_car"
                      required="required"
                      class="marc form-control form-control-sm"
                    >
                      <option></option>
                      {todosOsCarros.map((x) => (
                        <option> {x.marca} </option>
                      ))}
                    </select>
                  </p>

                  <p>
                    <label className="inf">Modelo do carro</label>
                    <br />
                    <select
                      onChange={(e) => retornarCarroPeloModelo(e.target.value)}
                      id="marc_car"
                      name="marc_car"
                      required="required"
                      class="mar form-control form-control-sm"
                    >
                      <option selected value="1"></option>
                      {carrosSeparadosPelaMarca.map((x) => (
                        <option>{x.modelo}</option>
                      ))}
                    </select>
                  </p>
                </div>

                <div className="anos">
                  <p>
                    <label for="ano_fab" className="inf1">
                      Ano Fabricação
                    </label>
                    <br />
                    <input
                      value={carroSeparadoPeloModelo.anoFabricacao}
                      id="ano_fab"
                      name="ano_fab"
                      required="required"
                      class="fab form-control form-control-sm"
                    ></input>
                  </p>

                  <p>
                    <label for="ano_ver" className="inf2  ">
                      Ano Versão
                    </label>
                    <br />
                    <input
                      value={carroSeparadoPeloModelo.anoModelo}
                      id="ano_ver"
                      name="ano_ver"
                      required="required"
                      class="vers form-control form-control-sm"
                    ></input>
                  </p>
                </div>

                <p>
                  <label for="cor_car" className="inf3">
                    Cor
                  </label>
                  <br />
                  <input
                    value={carroSeparadoPeloModelo.cor}
                    id="cor_car"
                    name="cor_car"
                    required="required"
                    class="cor form-control form-control-sm"
                  />
                </p>

                <div className="marq">
                  <h4>Marque seu Test-Drive</h4>
                  <p>
                    <label className="datetime">Data</label>
                    <input className="dat" required="required" type="date" />
                    <label className="datetime">Hora</label>
                    <input type="time" />
                  </p>

                  <p>
                    <input
                      type="submit"
                      value="Cadastrar"
                      class="btn btn-success"
                    />
                  </p>
                </div>
              </form>
            </div>
          </div>
        </div>
      </ContainerTotal>
    );
}