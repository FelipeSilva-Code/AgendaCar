import React from'react'
import './Style.css'
import ContainerTotal from '../../../Components/ContainerTotal'
import BlueContainer from '../../../Components/BlueContainer'
import { Link } from 'react-router-dom'

export default function Home () {
    return (
      <ContainerTotal
       menu={
       <>  
       <button className="btn btn-danger">&nbsp; Login &nbsp;</button>
       <button className="btn btn-danger">Cadastrar</button>
       </>
       }>
        <h4 className="tituloHome">
          Bem vindo ao AgendaCar
          <br /> Somos uma empresa que foca na facilidade e na comodidade
          para o agendamento de <br/> Tests Drives
        </h4>

        <div className="cardsHome">
          <BlueContainer>
            <h3>Já tem uma conta?</h3>
            <p className="txtHome">
              Se você ja tem uma conta basta clicar no botão abaixo e então você
              poderá agendar os seus test drives.
            </p>

            <button type="button" className="btn btn-success">
              <Link className="linkHome" to="/login">
                Entrar
              </Link>
            </button>
          </BlueContainer>

          <BlueContainer>
            <h3>Ainda não possui uma conta?</h3>

            <p className="txtHome">
              Se você ainda não tem uma conta ta esperando o que? Não perca
              mais tempo e se cadastre logo para poder agendar os seus tests
              drives.
            </p>

            <button type="button" className="btn btn-success">
              <Link className="linkHome" to="/cadastrar">
                Cadastrar
              </Link>
            </button>
          </BlueContainer>
        </div>
      </ContainerTotal>
    );
}