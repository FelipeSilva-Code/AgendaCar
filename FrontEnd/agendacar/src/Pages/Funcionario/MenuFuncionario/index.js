import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import ContainerTotal from "../../../Components/ContainerTotal";
import BlueContainer from "../../../Components/BlueContainer"
import "./styles.css";

export default function MenuFuncionario(props) {
  const [idUsuario] = useState(props.location.state.idUsuario);
  const [perfil] = useState(props.location.state.perfil);
  const [total] = useState({
    idUsuario,
    perfil
  })

  const history = useHistory();

  if (idUsuario === null || idUsuario === undefined) {
    history.push("/");
  }
  return (
    <ContainerTotal>
      <h3>Menu Funcionário</h3>

      <div className="containerMenuFuncionario">

    
        <BlueContainer>
           <h3>Ver Meus Agendamentos</h3>

            <p>
             Veja os seus test drives agendados.
            </p>

            <Link to = {{
            pathname:`/Funcionario/agendados`,
            state: total,
            }}>
              <button type="button" className="btn btn-success">
              Ver Agendamentos
              </button>
            </Link>
  
        </BlueContainer>
  

        <BlueContainer>
           <h3>Esperando Aprovação</h3>

            <p>
             Veja os test drives que estão esperando aprovação.
            </p>

            <Link to = {{
            pathname:`/Funcionario/Pendentes`,
            state: total,
            }}>
              <button type="button" className="btn btn-success">
              Ver Pendentes
              </button>
            </Link>
  
        </BlueContainer>

      </div>  

       <div className="containerMenuFuncionario">

    
        <BlueContainer>
           <h3>Adicionar Novo Carro</h3>

            <p>
             Adicione um novo carro para os tests drives.
            </p>

            <Link to = {{
            pathname:`/Funcionario/AdicionarCarro`,
            state: total,
            }}>
              <button type="button" className="btn btn-success">
              Adicionar
              </button>
            </Link>
  
        </BlueContainer>
  

        <BlueContainer>
           <h3>Ver Carros Cadastrados</h3>

            <p>
             Veja os carros cadastrados para tests drives.
            </p>

            <Link to = {{
            pathname:`/Funcionario/ListarCarros`,
            state: total,
            }}>
              <button type="button" className="btn btn-success">
              Ver Cadastrados
              </button>
            </Link>
  
        </BlueContainer>

      </div>  
       
     
    </ContainerTotal>
  );
}
