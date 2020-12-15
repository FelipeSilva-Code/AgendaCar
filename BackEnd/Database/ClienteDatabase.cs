using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class ClienteDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        Database.GeralDatabase dbGeral = new Database.GeralDatabase();
        public List<Models.TbAgendamento> ListarAgendados(int idcliente)
        {
            List<Models.TbAgendamento> agendamento = new List<Models.TbAgendamento>();
            agendamento = ctx.TbAgendamento.Where(x => x.IdCliente == idcliente)
                                           .Include(x => x.IdCarroNavigation)
                                           .Include(x => x.IdClienteNavigation)
                                           .Include(x => x.IdFuncionarioNavigation).ToList();

            agendamento = dbGeral.AlterarSituacaoSeNinguemAceitar(agendamento);                               
            return agendamento;
        }

        public void AvaliarTestDriver(int id, Models.Request.AvaliacaoRequest nota)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == id);

            agendamento.NrAvaliacao = nota.Nota;

            ctx.SaveChanges();
        }

        public void AgendarNovo (Models.TbAgendamento request)
        { 
            ctx.TbAgendamento.Add(request);
            ctx.SaveChanges();

        }

        public List<Models.TbCarro> ListarCarrosDisponiveis ()
        {
             List<Models.TbCarro> ListarCarros = ctx.TbCarro.Where(x => x.BtDisponivel == true).ToList();
             return ListarCarros;

        }

        public List<Models.TbCarro> ListarCarrosPorMarca (string marca)
        {
            List<Models.TbCarro> ListarCarros = this.ListarCarrosDisponiveis();
            return ListarCarros.Where(x => x.DsMarca == marca).ToList();
        }

        public Models.TbCarro PegarCarroPeloModelo(string modelo)
        {
           List<Models.TbCarro> listaDeDisponiveis = this.ListarCarrosDisponiveis();
           Models.TbCarro carro = listaDeDisponiveis.FirstOrDefault(x => x.DsModelo == modelo);
           return carro;
        }

        public void MarcarCarroComoIndisponivel(int? idCarro)
        {
            Models.TbCarro carro = ctx.TbCarro.FirstOrDefault(x => x.IdCarro == idCarro);

            carro.BtDisponivel = false;

            ctx.SaveChanges();
        }

       
    }
}