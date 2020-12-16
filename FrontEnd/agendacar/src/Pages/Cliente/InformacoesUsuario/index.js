import React, { useEffect, useState } from "react";
import "./styles.css";
import ContainerTotal from "../../../Components/ContainerTotal";
import { Link } from "react-router-dom";
import TestDriveApi from "../../../Services/TestDriverApi";
import {toast, ToastContainer} from "react-toastify"
import InputMask from "react-input-mask"

const api = new TestDriveApi();

export default function InformacoesUsuario(props) {

    const [idUsuario, setIdUsuario] = useState(props.location.state);
    const [nome, setNome] = useState();
    const [dataNascimento, setDataNascimento] = useState();
    const [cnh, setCnh] = useState();
    const [cpf, setCpf] = useState();
    const [telefone, setTelefone] = useState();
    const [email, setEmail] = useState();
    const [senha, setSenha] = useState();
    const [foto, setFoto] = useState();
    const [url, setUrl] = useState();
    const [imagemUsuario, setImagemUsuario] = useState();

    const pegarInfoUsuario = async () => {

      try {

          const resp = await api.pegarInformacoesUsuario(idUsuario);

          setNome(resp.nome);
          setDataNascimento(resp.dataNascimento.substr(0, 10));
          setCnh(resp.cnh);
          setCpf(resp.cpf);
          setTelefone(resp.telefone);
          setEmail(resp.email);
          setSenha(resp.senha);
          setFoto(resp.imagemUsuario);

          buscarFoto(resp.imagemUsuario);

          console.log(resp);
        
      } catch (e) {
        console.log(e);
        toast.error(e.response.data.mensagem);
      }
    }

    const buscarFoto = (fotoDePerfil) => {
      const urlDaFoto = api.buscarFotoUsuario(fotoDePerfil);
      setUrl(urlDaFoto);
    }

    const alterarInformacoes = async () => {
      try {
            const req = {
              Nome: nome,
              DataNascimento: dataNascimento,
              CNH: cnh,
              CPF: cpf,
              Telefone: telefone,
              Email: email,
              Senha: senha,
              ImagemUsuario: imagemUsuario,
            };

            console.log(req);

            await api.alterarInformacoesUsuario(req, idUsuario);

            setImagemUsuario(null);

            toast.success("Informações alteradas!")

            await pegarInfoUsuario();
        
      } catch (e) {
          toast.error(e.response.data.mensagem);
          console.log(e.response.data.mensagem)
      }
    }

    useEffect(() => {
      pegarInfoUsuario();
    }, []);
  return (
    <ContainerTotal>
      <ToastContainer/>
      <div className="containerAlterarInformacoes">
        <div className="divFotoUsuario">
          <div>
            <div className="fotoUsuario">
              <img className="imgFotoUsuario" src={url} alt="foto perfil" />
            </div>
            <h4>Alterar Foto</h4>
            <input onChange={e => setImagemUsuario(e.target.files[0])} type="file" />
          </div>
        </div>

        <div className="containerComAsInformacoes">
          <div>
            <label>
              Nome:
              <input onChange={e => setNome(e.target.value)} value={nome} className="form-control" type="text" />
            </label>

            <label>
              Data de nascimento:
              <input
                onChange={e => setDataNascimento(e.target.value)}
                value={dataNascimento}
                className="form-control"
                type="date"
              />
            </label>
          </div>

          <div>
            <label>
              CNH:
              <input onChange={e => setCnh(e.target.value)} value={cnh} className="form-control" type="text" />
            </label>

            <label>
              CPF:
              <InputMask mask="999.999.999-99" onChange={e => setCpf(e.target.value)} value={cpf} className="form-control" type="text" />
            </label>
          </div>

          <div>
            <label>
              Telefone:
              <InputMask mask="(99) 9999-99999" onChange={e => setTelefone(e.target.value)} value={telefone} className="form-control" type="text" />
            </label>

            <label>
              E-mail:
              <input onChange={e => setEmail(e.target.value)} value={email} className="form-control" type="text" />
            </label>
          </div>

          <div>
            <label>
              Senha:
              <input readOnly value={senha} className="form-control" type="password" />
            </label>
          </div>

          <div>
            <div className="divBtnsInfo">
              <button className="btn btn-danger">Cancelar</button>
              <button onClick={alterarInformacoes} className="btn btn-success">&nbsp; Salvar &nbsp;</button>
            </div>
          </div>
        </div>
      </div>
    </ContainerTotal>
  );
}
