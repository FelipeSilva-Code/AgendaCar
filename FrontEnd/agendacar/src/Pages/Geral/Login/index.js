import React, { useState } from 'react';
import './index.css';
import ContainerTotal from '../../../Components/ContainerTotalDeslogado';
import { Link, useHistory } from 'react-router-dom';
import TestDriverApi from '../../../Services/TestDriverApi';
import { ToastContainer, toast } from "react-toastify";

const api = new TestDriverApi();
export default function Login () {

  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState(0);

  const history = useHistory();

  const logarClick = async () => {

    try {
     
      const resp = await api.logar({
        Email: email,
        Senha: senha,
      });

      console.log(resp);
      
        history.push({
          pathname: resp.perfil + "/menu",
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
        <label htmlFor="nome_login">E-mail:</label>
        <input
          onChange={(e) => setEmail(e.target.value)}
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

      <Link className="linkCadastrar" to="/ProcurarConta">
        Esqueceu a Senha?
      </Link>

    </div>
    <ToastContainer/>
  </ContainerTotal>
);
}

