import React, { useEffect, useState } from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotal";
import { Link } from "react-router-dom";
import TestDriveApi from "../../../Services/TestDriverApi";
import {toast, ToastContainer} from "react-toastify"

const api = new TestDriveApi();

export default function InformacoesUsuario(props) {

    const [idUsuario, setIdUsuario] = useState(props.location.state);
    const [nome, setNome] = useState("");
    const [dataNascimento, setDataNascimento] = useState();
    const [cnh, setCnh] = useState("");
    const [cpf, setCpf] = useState("");
    const [telefone, setTelefone] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [foto, setFoto] = useState();
    const [url, setUrl] = useState();

    const pegarInfoUsuario = async () => {

      try {
          console.log("Olaaa");

          const resp = await api.pegarInformacoesUsuario(idUsuario);

          setNome(resp.nome);
          setDataNascimento(resp.dataNascimento.substr(0, 10));
          setCnh(resp.cnh);
          setCpf(resp.cpf);
          setTelefone(resp.telefone);
          setEmail(resp.telefone);
          setSenha(resp.telefone);
          setFoto(resp.imagemUsuario);


          buscarFoto(resp.imagemUsuario);

        

          console.log(resp);
        
      } catch (e) {
        toast.error(e.response.data.mensagem);
      }
    }

    const buscarFoto = (imagemUsuario) => {
      const urlDaFoto = api.buscarFotoUsuario(imagemUsuario);
      console.log(urlDaFoto);
      setUrl(urlDaFoto);
    }

    useEffect(() => {
      pegarInfoUsuario();
    }, []);
  return (
    <ContainerTotal>
      <div className="containerAlterarInformacoes">
        <div className="divFotoUsuario">
          <div>
            <div className="fotoUsuario">
              <img className="imgFotoUsuario" src={api.buscarFotoUsuario(foto)} alt="foto perfil" />
            </div>
            <h4>Alterar Foto</h4>
            <input type="file" />
          </div>
        </div>

        <div className="containerComAsInformacoes">
          <div>
            <label>
              Nome:
              <input value={nome} className="form-control" type="text" />
            </label>

            <label>
              Data de nascimento:
              <input
                value={dataNascimento}
                className="form-control"
                type="date"
              />
            </label>
          </div>

          <div>
            <label>
              CNH:
              <input value={cnh} className="form-control" type="text" />
            </label>

            <label>
              CPF:
              <input value={cpf} className="form-control" type="text" />
            </label>
          </div>

          <div>
            <label>
              Telefone:
              <input value={telefone} className="form-control" type="text" />
            </label>

            <label>
              E-mail:
              <input value={email} className="form-control" type="text" />
            </label>
          </div>

          <div>
            <label>
              Senha:
              <input value={senha} className="form-control" type="password" />
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
