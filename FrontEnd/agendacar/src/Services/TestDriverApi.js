import axios from 'axios'

const api = axios.create({
    baseURL: "http://localhost:5000"
})


export default class TestDriverApi {

    cadastrarCliente = async (cadastroRequest) => {
        let formData = new FormData();
        formData.append('nome', cadastroRequest.Nome);
        formData.append('dataNascimento', cadastroRequest.DataNascimento);
        formData.append('cnh', cadastroRequest.CNH);
        formData.append('cpf', cadastroRequest.CPF);
        formData.append('telefone', cadastroRequest.Telefone);
        formData.append('email', cadastroRequest.Email);
        formData.append('senha1', cadastroRequest.Senha1);
        formData.append('senha2', cadastroRequest.Senha2);
        formData.append('imagemUsuario', cadastroRequest.ImagemUsuario);

        const resp = await api.post("/CadastroCliente", formData, {
            headers: {'content-type': 'multipart/form-data'}
        });

        return resp.data;
    
    }

    logar = async (loginRequest) => {
        const resp = await api.post("/Geral/login", loginRequest);
        return resp.data;
    }

    agendadosDoCliente = async (idUsuario) =>  {
       const resp = await api.get(`/cliente/agendados/${idUsuario}`);
       return resp.data;    
    }

    avaliarTestDrive = async (id, nota) => {
       const resp = await api.put(`/cliente/agendados/avaliar/${id}`, nota)
       return resp;
    }

    agendadosDoFuncionario = async (idFuncionario) => {
        const resp = await api.get(`/Funcionario/agendados/${idFuncionario}`)
        return resp.data;
    }

    esperandoAprovacao = async () => {
        const resp = await api.get(`/Funcionario/EsperandoAceitacao`)
        return resp.data;
    }

    aceitarAgendamento = async (idFuncionario, idAgendamento) => {
        const resp = await api.put( `/Funcionario/Aceitar/${idFuncionario}/${idAgendamento}`);
        return resp.data;
    }

    mudarSituacao = async (idAgendamento, situacaoRequest) => {
        const resp = await api.put(`/Funcionario/MudarSituacao/${idAgendamento}`, situacaoRequest);
        return resp.data;
    }

    listarTodosOsCarros = async () => {
       const resp = await api.get("/Cliente/listar/carro");
       return resp.data;  
    }

    listarCarrosPelaMarca = async (marca) => {
        const resp = await api.get(`/Cliente/${marca}/listar`);
        return resp.data;
    }

    voltarCarroPeloModelo = async (modelo) => {
        const resp = await api.get(`/Cliente/${modelo}/carroUnico`)
        return resp.data;
    }

    agendarTestCliente = async (request) => {
        const resp = await api.post(`/Cliente/Agendar`, request);
        return resp.data;
    }

    pegarInformacoesUsuario = async (idUsuario) => {
        const resp = await api.get(`/InformacoesUsuario/${idUsuario}`);
        return resp.data;
    }

    buscarFotoUsuario = (nomeFoto) => {
        const resp = api.defaults.baseURL + "/Geral/PegarFoto/" + nomeFoto;
        
        return resp;
    }

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
    }

    alterarSenha = async (senhaRequest, idUsuario) => {
        const resp = await api.put("/InformacoesUsuario/AlterarSenha/" + idUsuario, senhaRequest);
        return resp.data;
    }
}