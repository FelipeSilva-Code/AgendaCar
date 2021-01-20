import axios from 'axios'

const api = axios.create({
    baseURL: "http://localhost:5000"
})


export default class TestDriverApi {


      //Funções que são acionadas pelo cliente
      cadastrarCliente = async (cadastroRequest) => {
        let formData = new FormData();
        formData.append("nome", cadastroRequest.Nome);
        formData.append("dataNascimento", cadastroRequest.DataNascimento);
        formData.append("cnh", cadastroRequest.CNH);
        formData.append("cpf", cadastroRequest.CPF);
        formData.append("telefone", cadastroRequest.Telefone);
        formData.append("email", cadastroRequest.Email);
        formData.append("senha1", cadastroRequest.Senha1);
        formData.append("senha2", cadastroRequest.Senha2);
        formData.append("imagemUsuario", cadastroRequest.ImagemUsuario);

        const resp = await api.post("/CadastroCliente", formData, {
          headers: { "content-type": "multipart/form-data" },
        });

        return resp.data;
      };

      agendadosDoCliente = async (idUsuario) => {
        const resp = await api.get(`/VerAgendamentos/agendados/cliente/${idUsuario}`);
        return resp.data;
      };

      listarTodosOsCarros = async () => {
        const resp = await api.get("/NovoAgendamento/listar/carro");
        return resp.data;
      };

      listarCarrosPelaMarca = async (marca) => {
        const resp = await api.get(`/NovoAgendamento/${marca}/listar`);
        return resp.data;
      };

      voltarCarroPeloModelo = async (modelo) => {
        const resp = await api.get(`/NovoAgendamento/${modelo}/carroUnico`);
        return resp.data;
      };

      agendarTestCliente = async (request) => {
        const resp = await api.post(`/NovoAgendamento/Agendar`, request);
        return resp.data;
      };

      avaliarTestDrive = async (id, nota) => {
        const resp = await api.put(`/Avaliacao/${id}`, nota);
        return resp;
      };

      pegarInformacoesUsuario = async (idUsuario) => {
        const resp = await api.get(`/InformacoesUsuario/${idUsuario}`);
        return resp.data;
      };


      alterarInformacoesUsuario = async (novasInformacoes, idUsuario) => {
        let formData = new FormData();
        formData.append("nome", novasInformacoes.Nome);
        formData.append("dataNascimento", novasInformacoes.DataNascimento);
        formData.append("cnh", novasInformacoes.CNH);
        formData.append("cpf", novasInformacoes.CPF);
        formData.append("telefone", novasInformacoes.Telefone);
        formData.append("email", novasInformacoes.Email);
        formData.append("senha", novasInformacoes.Senha1);
        formData.append("imagemUsuario", novasInformacoes.ImagemUsuario);

        const resp = await api.put("/InformacoesUsuario/" + idUsuario, formData, {
          headers: { "content-type": "multipart/form-data" },
        });

        return resp.data;
      };

      alterarSenhaCliente = async (senhaRequest, idUsuario) => {
        const resp = await api.put( "/InformacoesUsuario/AlterarSenha/" + idUsuario, senhaRequest);
        return resp.data;
      };



      // Funções que são acionadas pelo funcionário
      agendadosDoFuncionario = async (idFuncionario) => {
        const resp = await api.get(`/VerAgendamentos/agendados/funcionario/${idFuncionario}`);
        return resp.data;
      };

      esperandoAprovacao = async () => {
        const resp = await api.get(`/AlteracaoDeSituacao/EsperandoAceitacao`);
        return resp.data;
      };

      aceitarAgendamento = async (idFuncionario, idAgendamento) => {
        const resp = await api.put(`/NovoAgendamento/Aceitar/${idFuncionario}/${idAgendamento}`);
        return resp.data;
      };

      mudarSituacao = async (idAgendamento, situacaoRequest) => {
        console.log(situacaoRequest);
        const resp = await api.put(`/AlteracaoDeSituacao/MudarSituacao/${idAgendamento}?situacao=${situacaoRequest}`);
        return resp.data;
      };

       adicionarCarro = async (request) => {
        const resp = await api.post("/Carro", request);
        return resp.data;
      }

      buscarCarro = async (request) => {
        const resp = await api.get("/Carro?busca=" + request);
        return resp.data;
      }

      deletarCarro = async (idCarro) => {
        const resp = await api.delete("/Carro/" + idCarro);
        return resp.data;
      }

      pegarSomenteUmCarro = async (idCarro) => {
        const resp = await api.get("/Carro/pegarCarro/" + idCarro);
        return resp.data;
      }

      alterarInfoCarro = async (idCarro, request) => {
        const resp = await api.put("/Carro/" + idCarro, request );
        return resp.data;
      }
      
      pegarInfoCliente = async (nome) => {
        const resp = await api.get("/ProcuraPorUsuario/cliente?nome=" + nome);
        return resp.data;
      }

      procurarInfoFuncionario = async (nome) => {
        const resp = await api.get("/ProcuraPorUsuario/funcionario?nome=" + nome);
        return resp.data;
      }

      pegarTodosOsAgendamentos = async () => {
        const resp = await api.get("/VerAgendamentos/pegarTodosAgendamentos");
        return resp.data;
      }

      excluirUsuario = async (idUsuario) => {
        const resp = await api.delete(`/ProcuraPorUsuario/${idUsuario}`);
        return resp.data;
      } 

      cadastrarFuncionario = async (cadastroRequest) => {
        let formData = new FormData();
        formData.append("nome", cadastroRequest.Nome);
        formData.append("dataNascimento", cadastroRequest.DataNascimento);
        formData.append("cpf", cadastroRequest.CPF);
        formData.append("carteiraTrabalho", cadastroRequest.CarteiraTrabalho);
        formData.append("telefone", cadastroRequest.Telefone);
        formData.append("email", cadastroRequest.Email);
        formData.append("senha1", cadastroRequest.Senha1);
        formData.append("senha2", cadastroRequest.Senha2);
        formData.append("imagemUsuario", cadastroRequest.ImagemUsuario);

        const resp = await api.post("/CadastroFuncionario", formData, {
          headers: { "content-type": "multipart/form-data" },
        });

        return resp.data;
      };

      pegarInfoFuncionario = async (idUsuario) => {
        const resp = await api.get("InformacoesUsuario/infoFuncionario/" + idUsuario);
        return resp.data;
      }

      alterarInfoFuncionario = async (alterarRequest, idUsuario) => {
        let formData = new FormData();
        formData.append("nome", alterarRequest.Nome);
        formData.append("dataNascimento", alterarRequest.DataNascimento);
        formData.append("cpf", alterarRequest.CPF);
        formData.append("carteiraTrabalho", alterarRequest.CarteiraTrabalho);
        formData.append("telefone", alterarRequest.Telefone);
        formData.append("email", alterarRequest.Email);
        formData.append("senha1", alterarRequest.Senha1);
        formData.append("senha2", alterarRequest.Senha2);
        formData.append("imagemUsuario", alterarRequest.ImagemUsuario);

        const resp = await api.put("InformacoesUsuario/alterarInfoFuncionario/" + idUsuario, formData, {
          headers: { "content-type": "multipart/form-data" },
        });

        return resp.data;
      }

      alterarSenhaFuncionario = async (senhaRequest, idUsuario) => {
        const resp = await api.put( "/InformacoesUsuario/AlterarSenha/Funcionario/" + idUsuario, senhaRequest);
        return resp.data;
      };
  



      // Funções que tanto o funcionário e o cliente utilizam
      logar = async (loginRequest) => {
        const resp = await api.post("/Login", loginRequest);
        return resp.data;
      };

      buscarFotoUsuario = (nomeFoto) => {
        const resp = api.defaults.baseURL + "/Login/PegarFoto/" + nomeFoto;
        return resp;
      };
      
      procurarConta = async (email) => {
        const resp = await api.get("/EsqueceuSenha?email=" + email);
        return resp.data;
      } 
      
      gerarCodigo = async (email) => {
        const resp = await api.post("/EsqueceuSenha?email=" + email);
        return resp.data;
      }

      mudarSenhaPorqueEsqueceu = async (request, idLogin) => {
        const resp = await api.put("/EsqueceuSenha/" + idLogin, request);
        return resp.data;
      }   
      
      remarcarAgendamento = async (novoHorario, idAgendamento) => {
        const resp = await api.put(`NovoAgendamento/remarcar/${idAgendamento}?novoHorario=${novoHorario}`);
        return resp.data;
      }
      
      
}