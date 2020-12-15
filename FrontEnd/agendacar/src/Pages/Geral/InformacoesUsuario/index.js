import React, { useState } from "react";
import "./styles.css";
import ContainerTotal from "./../../../Components/ContainerTotal";
import { Link } from "react-router-dom";

export default function InformacoesUsuario() {

    const [nome, setNome] = useState("");
    const [dataNascimento, setDataNascimento] = useState();
    const [cnh, setCnh] = useState("");
    const [cpf, setCpf] = useState("");
    const [telefone, setTelefone] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [foto, setFoto] = useState();
  return (
    <ContainerTotal>
      <div className="containerAlterarInformacoes">
        <div className="divFotoUsuario">
          <div>
            <div className="fotoUsuario">
              <img
                className="imgFotoUsuario"
                src="https://www.dicasdemulher.com.br/wp-content/uploads/2019/05/legenda-para-foto-na-praia.jpg"
              />
            </div>
            <h4>Alterar Foto</h4>
            <input type="file" />
          </div>
        </div>

        <div className="containerComAsInformacoes">
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

          <div>
            <div className="divBtnsInfo">
              <button className="btn btn-danger">Cancelar</button>
              <button className="btn btn-success">&nbsp; Salvar &nbsp;</button>
            </div>
          </div>
        </div>
      </div>
    </ContainerTotal>
  );
}
