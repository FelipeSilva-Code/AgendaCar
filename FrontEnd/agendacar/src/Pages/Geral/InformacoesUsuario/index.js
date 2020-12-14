import React, { useState } from "react";
import "./styles.css";
import ContainerTotal from "./../../../Components/ContainerTotal";
import { Link } from "react-router-dom";

export default function InformacoesUsuario() {

    const [nome, setNome] = useState();
    const [dataNascimento, setDataNascimento] = useState();
    const [cnh, setCnh] = useState();
    const [cpf, setCpf] = useState();
    const [telefone, setTelefone] = useState();
    const [email, setEmail] = useState();
    const [senha, setSenha] = useState();
    const [foto, setFoto] = useState();
  return (
    <ContainerTotal>
      <div className="containerCadastrar">
        <h2>Suas Informações</h2>

        <div className="divFotoUsuario">
            <div>
                <div className="fotoUsuario">
                    <h3>Foto do Usuário</h3>
                </div>
            </div>
        </div>    

        <div>
          <label>
            Nome:
            <input className="form-control" type="text" />
          </label>

          <label>
            Data de nascimento:
            <input className="form-control" type="date" />
          </label>
        </div>

        <div>
          <label>
            CNH:
            <input className="form-control" type="text" />
          </label>

          <label>
            CPF:
            <input className="form-control" type="text" />
          </label>
        </div>

        <div>
          <label>
            Telefone:
            <input className="form-control" type="text" />
          </label>

          <label>
            E-mail:
            <input className="form-control" type="text" />
          </label>
        </div>

        <div>
          <label>
            Senha:
            <input className="form-control" type="password" />
          </label>

        
        </div>

        <div className="adicionarFotoCadastrar">
          <div className="divAdicionarFotoCadastrar">
            <label className="labelAdicionarFotoCadastrar">
              Adicione uma foto (opcional):
              <div className="custom-file">
                <input
                  type="file"
                  className="custom-file-input"
                  id="inputGroupFile04"
                  aria-describedby="inputGroupFileAddon04"
                />
                <label className="custom-file-label" htmlFor="inputGroupFile04">
                  Escolher arquivo
                </label>
              </div>
            </label>
          </div>
        </div>

        <button className="btn btn-success">Cadastrar</button>

        <Link className="linkCadastrar" to="/login">
          Já tem uma contra? Logar
        </Link>
      </div>
    </ContainerTotal>
  );
}
