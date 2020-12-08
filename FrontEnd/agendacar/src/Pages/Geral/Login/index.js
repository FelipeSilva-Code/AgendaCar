import React, { useState } from 'react';
import './index.css';
import ContainerTotal from '../../../Components/ContainerTotal';
import { Link, useHistory } from 'react-router-dom';
import TestDriverApi from '../../../Services/TestDriverApi';
import { ToastContainer, toast } from "react-toastify";

const api = new TestDriverApi();
export default function Login () {

  const [cpf, setCpf] = useState(0);
  const [senha, setSenha] = useState(0);

  const history = useHistory();

  const logarClick = async () => {

    try {
     
      const resp = await api.logar({
        CPF: cpf,
        Senha: senha,
      });
      
        history.push({
          pathname: resp.perfil + "/menu/" + resp.idUsuario,
          state: resp
        })      

    } catch(e) {
     
      toast.error(e.response.data.mensagem);

    }
      
  }

return (
  <ContainerTotal>

    <div className="loginDiv">
      
      <h2>Login</h2>

      <div>
        <label htmlFor="nome_login">CPF:</label>
        <input
          onChange={(e) => setCpf(e.target.value)}
          className="form-control inputLogin"
          id="nome_login"
          name="nome_login"
          required="required"
          type="text"
        />
      </div>

      <div>
        <label htmlFor="email_login">Senha:</label>
        <input
          onChange={(e) => setSenha(e.target.value)}
          className="form-control inputLogin"
          id="email_login"
          name="email_login"
          required="required"
          type="password"
        />
      </div>

      <div>
        <button 
        onClick={logarClick}
        type="button" className="btn btn-success">
          Entrar
        </button>
      </div>

      <Link className="linkCadastrar" to="/cadastrar">
        Ainda não tem uma conta? Cadastre-se.
      </Link>
    </div>
    <ToastContainer/>
  </ContainerTotal>
);
}

