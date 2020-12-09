import axios from 'axios'

const api = axios.create({
    baseURL: "http://localhost:5000"
})


export default class TestDriverApi {

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
}