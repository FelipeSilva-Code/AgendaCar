import React, { useEffect, useState } from "react";
import ContainerTotal from "../../../Components/ContainerTotalLogado";
import { Link, useHistory } from "react-router-dom";
import TestDriveApi from "../../../Services/TestDriverApi";
import { toast, ToastContainer } from "react-toastify";
import InputMask from "react-input-mask";

const api = new TestDriveApi();

export default function InformacoesFuncionario(props) {


  const [idUsuario, setIdUsuario] = useState(props.location.state);
  const [nome, setNome] = useState();
  const [dataNascimento, setDataNascimento] = useState();
  const [carteiraTrabalho, setCarteiraTrabalho] = useState();
  const [cpf, setCpf] = useState();
  const [telefone, setTelefone] = useState();
  const [email, setEmail] = useState();
  const [senha, setSenha] = useState();
  const [foto, setFoto] = useState();
  const [url, setUrl] = useState();
  const [imagemUsuario, setImagemUsuario] = useState();

  const history = useHistory();

  const pegarInfoFuncionario = async () => {
    try {
  
      const resp = await api.pegarInfoFuncionario(idUsuario);

      setNome(resp.nome);
      setDataNascimento(resp.dataNascimento.substr(0, 10));
      setCarteiraTrabalho(resp.carteiraTrabalho);
      setCpf(resp.cpf);
      setTelefone(resp.telefone);
      setEmail(resp.email);
      setSenha(resp.senha);
      setFoto(resp.imagemUsuario);

      buscarFoto(resp.imagemUsuario);
    } catch (e) {
      toast.error(e.response.data.mensagem);
    }
  };

  const buscarFoto = (fotoDePerfil) => {
    const urlDaFoto = api.buscarFotoUsuario(fotoDePerfil);
    setUrl(urlDaFoto);
  };

  const alterarInformacoes = async () => {
    try {
      const req = {
        Nome: nome,
        DataNascimento: dataNascimento,
        CarteiraTrabalho: carteiraTrabalho,
        CPF: cpf,
        Telefone: telefone,
        Email: email,
        Senha: senha,
        ImagemUsuario: imagemUsuario,
      };

      await api.alterarInfoFuncionario(req, idUsuario);

      setImagemUsuario(null);

      toast.success("Informações alteradas!");

      await pegarInfoFuncionario();
    
    } catch (e) {
    
        toast.error(e.response.data.mensagem);
    
    }
  };

  const voltar = () => {
    const r = window.confirm("Todas as alterações não salvas serão perdidas.");
    if (r === true) history.goBack();
  };

  useEffect(() => {
    pegarInfoFuncionario();
  }, []);

  return (
    <ContainerTotal idUsuario={idUsuario} perfil="Funcionario">
      <ToastContainer />
      <div className="containerAlterarInformacoes">
        <div className="divFotoUsuario">
          <div>
            <div className="fotoUsuario">
              <img className="imgFotoUsuario" src={url} alt="foto perfil" />
            </div>
            <h4>Alterar Foto</h4>
            <input
              onChange={(e) => setImagemUsuario(e.target.files[0])}
              type="file"
            />
          </div>
        </div>

        <div className="containerComAsInformacoes">
          <div>
            <label>
              Nome:
              <input
                onChange={(e) => setNome(e.target.value)}
                value={nome}
                className="form-control"
                type="text"
              />
            </label>

            <label>
              Data de nascimento:
              <input
                onChange={(e) => setDataNascimento(e.target.value)}
                value={dataNascimento}
                className="form-control"
                type="date"
              />
            </label>
          </div>

          <div>
            <label>
              Carteira de Trabalho:
              <InputMask mask="999.99999.99.9"
                onChange={(e) => setCarteiraTrabalho(e.target.value)}
                value={carteiraTrabalho}
                className="form-control"
                type="text"
              />
            </label>

            <label>
              CPF:
              <InputMask
                mask="999.999.999-99"
                onChange={(e) => setCpf(e.target.value)}
                value={cpf}
                className="form-control"
                type="text"
              />
            </label>
          </div>

          <div>
            <label>
              Telefone:
              <InputMask
                mask="(99) 9999-99999"
                onChange={(e) => setTelefone(e.target.value)}
                value={telefone}
                className="form-control"
                type="text"
              />
            </label>

            <label>
              E-mail:
              <input
                onChange={(e) => setEmail(e.target.value)}
                value={email}
                className="form-control"
                type="text"
              />
            </label>
          </div>

          <div>
            <label>
              Senha:
              <input
                readOnly
                value={senha}
                className="form-control"
                type="password"
              />
            </label>

            <Link
              to={{ pathname: "/alterarsenha", state: {idUsuario: idUsuario, perfil: "Funcionario"} }}
              className="linkInfoUsuario"
            >
              <button className="btn btn-outline-light">Alterar Senha</button>
            </Link>
          </div>

          <div>
            <div className="divBtnsInfo">
              <button onClick={voltar} className="btn btn-danger">
                Cancelar
              </button>
              <button onClick={alterarInformacoes} className="btn btn-success">
                &nbsp; Salvar &nbsp;
              </button>
            </div>
          </div>
        </div>
      </div>
    </ContainerTotal>
  );
}
