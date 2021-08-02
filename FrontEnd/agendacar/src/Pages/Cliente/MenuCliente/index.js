import React, { useState } from'react'
import { useHistory, Link } from 'react-router-dom';
import ContainerTotal from '../../../Components/ContainerTotalLogado'
import BlueContainer from '../../../Components/BlueContainer'
import './Style.css'

export default function MenuCliente (props) {

    const [idUsuario, setIdUsuario] = useState(props.location.state.idUsuario);
    const [perfil, setPerfil] = useState(props.location.state.perfil);

    const [state] = useState({
        idUsuario,
        perfil
    })

    const history = useHistory();
    
    const mandarParaAgendados = () => {
        history.push({
          pathname: "/Cliente/Agendados",
          state: state
        });
    }

    const mandarParaCadastrar = () => {
        history.push({
            pathname: `/Cliente/Agendar`,
            state: state
        })
    }
    return (
      <ContainerTotal
       idUsuario={idUsuario} perfil="Cliente">
        <div className="tituloMenuCliente">
          <h3>
            Seja bem vindo ao AgendaCar, site especializado no agendamento de
            tests drives
          </h3>
        </div>

        <div className="cardsMenuCliente">
          <BlueContainer>
            <h3>Marcar Test Drive</h3>

            <p>
              Quer marcar um test drive? Não perca tempo. Temos horarios
              flexiveis e uma grande variedade de automóveis.
            </p>

            <button onClick={mandarParaCadastrar} type="button" className="btn btn-success">
              Marcar
            </button>
          </BlueContainer>

          <BlueContainer>
            <h3>Ver Agendados</h3>

            <p>
              Veja os seus tests drivers agendados, ficando sempre por dentro
              dos seus horários para nunca se atrasar.
            </p>

            <button onClick={mandarParaAgendados} type="button" className="btn btn-success">
              Agendados
            </button>
          </BlueContainer>
        </div>
      </ContainerTotal>
    );
}