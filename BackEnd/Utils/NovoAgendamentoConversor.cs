using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class NovoAgendamentoConversor
    {
        public Models.Response.CarrosDisponiveis ParaResponseCarro(Models.TbCarro listaDeCarros)
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

        public List<Models.Response.CarrosDisponiveis> ListarParaResponseCarro(List<Models.TbCarro> listaDeCarros, string tipo)
        {
            List<Models.Response.CarrosDisponiveis> listaCarrosDisponiveis = new List<Models.Response.CarrosDisponiveis>();
            List<Models.TbCarro> listaCarrosSomentePorUm = new List<Models.TbCarro>();

            if (tipo == "Marca")
                foreach (Models.TbCarro item in listaDeCarros)
                {
                    if (listaCarrosSomentePorUm.Any(x => x.DsMarca == item.DsMarca))
                        continue;
                    else
                        listaCarrosSomentePorUm.Add(item);
                }

            else if (tipo == "Modelo")
                foreach (Models.TbCarro item in listaDeCarros)
                {
                    if (listaCarrosSomentePorUm.Any(x => x.DsModelo == item.DsModelo))
                        continue;
                    else
                        listaCarrosSomentePorUm.Add(item);
                }

            foreach (Models.TbCarro item in listaCarrosSomentePorUm)
            {
                listaCarrosDisponiveis.Add(ParaResponseCarro(item));
            }

            return listaCarrosDisponiveis;
        }

        public Models.TbAgendamento ParaAgendamentoTabela(Models.Request.AgendarNovoRequest request)
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
    }
}