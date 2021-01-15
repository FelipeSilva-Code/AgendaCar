import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import ContainerTotal from "../../../Components/ContainerTotalLogado";
import BlueContainer from "../../../Components/BlueContainer";
import { toast, ToastContainer } from "react-toastify";
import "./styles.css";

export default function MenuFuncionario(props) {
  const [idUsuario] = useState(props.location.state.idUsuario);
  const [perfil] = useState(props.location.state.perfil);
  const [qualTelaIr, setQualTelaIr] = useState();
  
  const [mostrarAreaDoAdmin, setMostrarAreaDoAdmin] = useState(false);

  const [total] = useState({
    idUsuario,
    perfil
  })

  const mostrarAreaDoAdminClick = (telaQueVai) => {
    if(mostrarAreaDoAdmin == false)
    {
      setMostrarAreaDoAdmin(true);
      setQualTelaIr(telaQueVai);
    }
    else
    {
     setMostrarAreaDoAdmin(false);  
     setQualTelaIr(telaQueVai);
    }
  }

    const [senha, setSenha] = useState(1234);
    const [senhaPassada, setSenhaPassada] = useState();

    const history = useHistory();

    const verSeSenhaEstaCerta = () => {

        if(senha === senhaPassada && qualTelaIr === "VerAgendamentos")
            history.push({pathname:"/Funcionario/VerTodosAgendamentos", state: idUsuario});
        else if(senha === senhaPassada && qualTelaIr === "ProcurarUsuario")
            history.push({pathname:"/Funcionario/ProcurarUsuario", state: idUsuario});    
        else if(senha === senhaPassada && qualTelaIr === "Cadastrar")
            history.push({pathname:"/Funcionario/Cadastrar", state: idUsuario});
        else    
            toast.error("A senha está incorreta.")    
    }

  if (idUsuario === null || idUsuario === undefined) {
    history.push("/");
  }

  return (
    <>
      {mostrarAreaDoAdmin === true && (
        <div className="containerAreaDoAdmin">
          <ToastContainer />
          <div className="divInfoArea">
            <h4>Para acessar essa área é necessario inserir uma senha </h4>
            <p>
              (Se você não sabe a senha entre em contato com o administrador)
            </p>

            <label>
              Insira a Senha
              <input
                onChange={(e) => setSenhaPassada(Number(e.target.value))}
                className="form-control"
              ></input>
            </label>

            <div className="divBtnsAreaAdmin">
              <button onClick={() => mostrarAreaDoAdminClick("Nada")} className="btn btn-danger">
                Cancelar
              </button>
              <button onClick={verSeSenhaEstaCerta} className="btn btn-success">
                Confirmar
              </button>
            </div>
          </div>
        </div>
      )}

      <ContainerTotal idUsuario={idUsuario} perfil="Funcionario">
        <h2>Bem-Vindo ao Menu do Funcionário</h2>

        <div className="containerMenuFuncionario">
          <h2 className ="titleContainerMenuFuncionario">Agendamentos</h2>
          <BlueContainer>
            <h3>Ver Meus Agendamentos</h3>

            <p>Veja os seus test drives agendados.</p>

            <Link
              to={{
                pathname: `/Funcionario/agendados`,
                state: total,
              }}
            >
              <button type="button" className="btn btn-success">
                Ver Agendamentos
              </button>
            </Link>
          </BlueContainer>

          <BlueContainer>
            <h3>Esperando Aprovação</h3>

            <p>Veja os test drives que estão esperando aprovação.</p>

            <Link
              to={{
                pathname: `/Funcionario/Pendentes`,
                state: total,
              }}
            >
              <button type="button" className="btn btn-success">
                Ver Pendentes
              </button>
            </Link>
          </BlueContainer>
        </div>

        <div className="containerMenuFuncionario">
          <h2 className ="titleContainerMenuFuncionario">Carros</h2>
          <BlueContainer>
            <h3>Adicionar Novo Carro</h3>

            <p>Adicione um novo carro para os tests drives.</p>

            <Link
              to={{
                pathname: `/Funcionario/AdicionarCarro`,
                state: total,
              }}
            >
              <button type="button" className="btn btn-success">
                Adicionar
              </button>
            </Link>
          </BlueContainer>

          <BlueContainer>
            <h3>Ver Carros Cadastrados</h3>

            <p>Veja os carros cadastrados para tests drives.</p>

            <Link
              to={{
                pathname: `/Funcionario/ListarCarros`,
                state: total,
              }}
            >
              <button type="button" className="btn btn-success">
                Ver Cadastrados
              </button>
            </Link>
          </BlueContainer>
        </div>

        <div className="containerMenuFuncionarioAreaDoAdmin">
          <h2 className ="titleContainerMenuFuncionario">Area do Admin</h2>
          <BlueContainer>
            <h3>Ver Todos Os Agendamentos</h3>

            <p>Veja todos os tests drives agendados.</p>

            <button
              onClick={() => mostrarAreaDoAdminClick("VerAgendamentos")}
              type="button"
              className="btn btn-success"
            >
              Ver Agendamentos
            </button>
          </BlueContainer>

          <BlueContainer>
            <h3>Procurar Usuário</h3>

            <p>Procure por usuários, seja ele cliente ou funcionário.</p>

             <button 
               onClick={() => mostrarAreaDoAdminClick("ProcurarUsuario")} 
               type="button" 
               className="btn btn-success">
                Procurar Usuários
              </button>
           
          </BlueContainer>
  

          <BlueContainer>
            <h3>Adicionar Novo Funcionário</h3>

            <p>Adicione um novo funcionário.</p>

              <button 
               onClick={() => mostrarAreaDoAdminClick("Cadastrar")} 
               type="button" 
               className="btn btn-success">
                Adicionar
              </button>
            
          </BlueContainer>

        </div>
      </ContainerTotal>
    </>
  );
}
