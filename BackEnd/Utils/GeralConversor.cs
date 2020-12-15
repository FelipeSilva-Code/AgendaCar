using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class GeralConversor
    {
        Database.GeralDatabase db = new Database.GeralDatabase();
        public Models.Response.AgendadosResponse ParaResponseAgendados (Models.TbAgendamento agendamento)
        {
            Models.Response.AgendadosResponse resp = new Models.Response.AgendadosResponse();

            resp.idCliente = agendamento.IdClienteNavigation.IdCliente;
            resp.Marca = agendamento.IdCarroNavigation.DsMarca;
            resp.Modelo = agendamento.IdCarroNavigation.DsModelo;
            resp.Data = agendamento.DtAgendamento;
            
            if(agendamento.IdFuncionarioNavigation == null)
                resp.Funcionario = string.Empty;
            else
            resp.Funcionario = agendamento.IdFuncionarioNavigation.NmFuncionario;
           
            resp.idAgendamento = agendamento.IdAgendamento;
            resp.Situacao = agendamento.DsSituacao;

            return resp;
        }

        public List<Models.Response.AgendadosResponse> ListaResponseAgendados (List<Models.TbAgendamento> agendamentos)
        {
            List<Models.Response.AgendadosResponse> listaAgendados = new List<Models.Response.AgendadosResponse>();

            foreach(Models.TbAgendamento item in agendamentos)
                listaAgendados.Add(this.ParaResponseAgendados(item));

            return listaAgendados;
        }

        public Models.Response.AgendadosResponseCompleto SepararPorTipo (List<Models.TbAgendamento> agendamentos)
        {
            
            DateTime agora = DateTime.Now;
            DateTime amanha = DateTime.Now.AddDays(1);
            DateTime depois = DateTime.Now.AddDays(2);

            Models.Response.AgendadosResponseCompleto responseCompleto = new Models.Response.AgendadosResponseCompleto();
            responseCompleto.Hoje = new List<Models.Response.AgendadosResponse> ();
            responseCompleto.Amanha = new List<Models.Response.AgendadosResponse> ();
            responseCompleto.Depois = new List<Models.Response.AgendadosResponse> ();
            responseCompleto.Concluidos = new List<Models.Response.AgendadosResponse>();
            responseCompleto.Outros = new List<Models.Response.AgendadosResponse> ();

            List<Models.Response.AgendadosResponse> listaAgendados = new List<Models.Response.AgendadosResponse>();

            listaAgendados = this.ListaResponseAgendados(agendamentos);

            foreach(Models.Response.AgendadosResponse item in listaAgendados)
            {
                if (item.Data.Value.Day == agora.Day && item.Situacao == "Aprovado")
                   responseCompleto.Hoje.Add(item);
                else if(item.Data.Value.Day == amanha.Day && item.Situacao == "Aprovado")
                   responseCompleto.Amanha.Add(item);
                else if(item.Data.Value.Date >= depois.Date && item.Situacao == "Aprovado")
                    responseCompleto.Depois.Add(item);   
                else if(item.Situacao == "Concluido")
                    responseCompleto.Concluidos.Add(item);
                else 
                    responseCompleto.Outros.Add(item);
            }

            responseCompleto.Hoje = responseCompleto.Hoje.OrderBy(x => x.Data).ToList();
            responseCompleto.Amanha = responseCompleto.Amanha.OrderBy(x => x.Data).ToList();
            responseCompleto.Depois = responseCompleto.Depois.OrderBy(x => x.Data).ToList();
            responseCompleto.Concluidos = responseCompleto.Concluidos.OrderByDescending(x => x.Data).ToList();
            responseCompleto.Outros = responseCompleto.Outros.OrderByDescending( x => x.Data ).ToList();

            return responseCompleto;
        }

        public Models.TbLogin ParaTbLogin (Models.Request.LoginRequest request)
        {
            Models.TbLogin tbLogin = new Models.TbLogin();
            
            tbLogin.DsEmail = request.Email;
            tbLogin.DsSenha = request.Senha;

            return tbLogin;
        }

        public Models.Response.LoginResponse ParaLoginResponse (Models.TbLogin request)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.IdUsuario = db.RetornarIdDoUsuario(request);

            resp.Perfil = request.DsPerfil;

            return resp;
        }

        public Models.TbAgendamento ParaAgendamentoTabela (Models.Request.AgendarNovoRequest request)
        {
            Models.TbAgendamento agendamento = new Models.TbAgendamento();
            agendamento.DsSituacao = "Pendente";
            agendamento.DtAgendamento = request.Data;
            agendamento.IdCarro = request.IdCarro;
            agendamento.IdFuncionario = null;
            agendamento.IdCliente = request.IdCliente;
            agendamento.NrAvaliacao = 0;

            return agendamento;
        }

        public List<Models.Response.AgendadosResponse> SomenteEsperandoAceitacao ( List<Models.TbAgendamento> agendamentos) 
        {
            List<Models.Response.AgendadosResponse> respose = this.ListaResponseAgendados(agendamentos);

            return respose.Where(x => x.Situacao == "Pendente" && x.Data > DateTime.Now).ToList();
        }

        public Models.Response.CarrosDisponiveis ParaResponseCarro (Models.TbCarro listaDeCarros)
        {
            Models.Response.CarrosDisponiveis response = new Models.Response.CarrosDisponiveis();
            
            response.AnoFabricacao = listaDeCarros.NrAnoFabricacao;
            response.AnoModelo = listaDeCarros.NrAnoVersao;
            response.Cor = listaDeCarros.DsCor;
            response.Id = listaDeCarros.IdCarro;
            response.Marca = listaDeCarros.DsMarca;
            response.Modelo = listaDeCarros.DsModelo;

            return response;
        }

        public List<Models.Response.CarrosDisponiveis> ListarParaResponseCarro (List<Models.TbCarro> listaDeCarros, string tipo)
        {
            List<Models.Response.CarrosDisponiveis> listaCarrosDisponiveis = new List<Models.Response.CarrosDisponiveis>();
            List<Models.TbCarro> listaCarrosSomentePorUm = new List<Models.TbCarro>();
           
            if(tipo == "Marca")
            foreach(Models.TbCarro item in listaDeCarros)
            {
                if(listaCarrosSomentePorUm.Any( x => x.DsMarca == item.DsMarca))
                   continue;
                else
                   listaCarrosSomentePorUm.Add(item);   
            }

            else if(tipo == "Modelo")
            foreach(Models.TbCarro item in listaDeCarros)
            {
                if(listaCarrosSomentePorUm.Any( x => x.DsModelo == item.DsModelo))
                   continue;
                else
                   listaCarrosSomentePorUm.Add(item);   
            }

            foreach(Models.TbCarro item in listaCarrosSomentePorUm)
            {
                listaCarrosDisponiveis.Add(ParaResponseCarro(item));
            }

            return listaCarrosDisponiveis;
        }
  
    }
}