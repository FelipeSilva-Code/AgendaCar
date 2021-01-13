using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Utils
{
    public class VerAgendamentosConversor
    {
        public Models.Response.AgendadosResponse ParaResponseAgendados(Models.TbAgendamento agendamento)
        {
            Models.Response.AgendadosResponse resp = new Models.Response.AgendadosResponse();

            resp.idCliente = agendamento.IdClienteNavigation.IdCliente;
            resp.Marca = agendamento.IdCarroNavigation.DsMarca;
            resp.Modelo = agendamento.IdCarroNavigation.DsModelo;
            resp.Data = agendamento.DtAgendamento;
            resp.Cliente = agendamento.IdClienteNavigation.NmCliente;
            resp.Nota = agendamento.NrAvaliacao;

            if (agendamento.IdFuncionarioNavigation == null)
                resp.Funcionario = string.Empty;
            else
                resp.Funcionario = agendamento.IdFuncionarioNavigation.NmFuncionario;

            resp.idAgendamento = agendamento.IdAgendamento;
            resp.Situacao = agendamento.DsSituacao;

            return resp;
        }

        public List<Models.Response.AgendadosResponse> ListaResponseAgendados(List<Models.TbAgendamento> agendamentos)
        {
            List<Models.Response.AgendadosResponse> listaAgendados = new List<Models.Response.AgendadosResponse>();

            foreach (Models.TbAgendamento item in agendamentos)
                listaAgendados.Add(this.ParaResponseAgendados(item));

            return listaAgendados;
        }

        public Models.Response.AgendadosResponseCompleto SepararPorTipo(List<Models.TbAgendamento> agendamentos)
        {

            DateTime agora = DateTime.Now;
            DateTime amanha = DateTime.Now.AddDays(1);
            DateTime depois = DateTime.Now.AddDays(2);

            Models.Response.AgendadosResponseCompleto responseCompleto = new Models.Response.AgendadosResponseCompleto();
            responseCompleto.Hoje = new List<Models.Response.AgendadosResponse>();
            responseCompleto.Amanha = new List<Models.Response.AgendadosResponse>();
            responseCompleto.Depois = new List<Models.Response.AgendadosResponse>();
            responseCompleto.Concluidos = new List<Models.Response.AgendadosResponse>();
            responseCompleto.Outros = new List<Models.Response.AgendadosResponse>();

            List<Models.Response.AgendadosResponse> listaAgendados = new List<Models.Response.AgendadosResponse>();

            listaAgendados = this.ListaResponseAgendados(agendamentos);

            foreach (Models.Response.AgendadosResponse item in listaAgendados)
            {
                if (item.Data.Value.Date == agora.Date && item.Situacao == "Aprovado")
                    responseCompleto.Hoje.Add(item);
                else if (item.Data.Value.Date == amanha.Date && item.Situacao == "Aprovado")
                    responseCompleto.Amanha.Add(item);
                else if (item.Data.Value.Date >= depois.Date && item.Situacao == "Aprovado")
                    responseCompleto.Depois.Add(item);
                else if (item.Situacao == "Concluido")
                    responseCompleto.Concluidos.Add(item);
                else
                    responseCompleto.Outros.Add(item);
            }

            responseCompleto.Hoje = responseCompleto.Hoje.OrderBy(x => x.Data).ToList();
            responseCompleto.Amanha = responseCompleto.Amanha.OrderBy(x => x.Data).ToList();
            responseCompleto.Depois = responseCompleto.Depois.OrderBy(x => x.Data).ToList();
            responseCompleto.Concluidos = responseCompleto.Concluidos.OrderByDescending(x => x.Data).ToList();
            responseCompleto.Outros = responseCompleto.Outros.OrderByDescending(x => x.Data).ToList();

            return responseCompleto;
        }
    }
}