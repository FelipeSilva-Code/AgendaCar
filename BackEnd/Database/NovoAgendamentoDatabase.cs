using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class NovoAgendamentoDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();

        public List<Models.TbCarro> ListarCarrosDisponiveis()
        {
            List<Models.TbCarro> ListarCarros = ctx.TbCarro.Where(x => x.BtDisponivel == true).ToList();
            return ListarCarros;

        }

        public List<Models.TbCarro> ListarCarrosPorMarca(string marca)
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
        public string AgendarNovo(Models.TbAgendamento request)
        {
            ctx.TbAgendamento.Add(request);
            ctx.SaveChanges();

            return this.PegarEmail(request.IdCliente);

        }

        public string PegarEmail (int? idCliente)
        {
            Models.TbCliente cliente = ctx.TbCliente.Include(x => x.IdLoginNavigation).FirstOrDefault(x => x.IdCliente == idCliente);
            return cliente.IdLoginNavigation.DsEmail;

        }

        public void MarcarCarroComoIndisponivel(int? idCarro)
        {
            Models.TbCarro carro = ctx.TbCarro.FirstOrDefault(x => x.IdCarro == idCarro);

            carro.QtdDisponivel -= 1;

            if(carro.QtdDisponivel == 0)
                carro.BtDisponivel = false;

            ctx.SaveChanges();
        }

        
        //Funcionário
        public Models.TbAgendamento AceitarAgendamento(int idFuncionario, int idAgendamento)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.Include(x => x.IdCarroNavigation)
                                               .Include(x => x.IdFuncionarioNavigation)
                                               .Include(x => x.IdClienteNavigation)
                                               .FirstOrDefault(x => x.IdAgendamento == idAgendamento);


            agendamento.IdFuncionario = idFuncionario;
            agendamento.DsSituacao = "Aprovado";
            ctx.SaveChanges();

            return agendamento;
        }

        public string PegarEmailUsuario (int? idCliente)
        {
            Models.TbCliente cliente = ctx.TbCliente.Include(x => x.IdLoginNavigation)
                                                .FirstOrDefault(x => x.IdCliente == idCliente);

            string email = cliente.IdLoginNavigation.DsEmail;

            return email;
        }

        //Ambos
        public Models.TbAgendamento PegarAgendamento (int idAgendamento)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.Include(x => x.IdCarroNavigation).Include(x => x.IdClienteNavigation).Include(x => x.IdFuncionarioNavigation).FirstOrDefault(x => x.IdAgendamento == idAgendamento);
            return agendamento;
        }

        public Models.TbAgendamento Remarcar (DateTime novoHorario, int idAgendamento)
        {
            Models.TbAgendamento agendamento = this.PegarAgendamento(idAgendamento);
            agendamento.DtAgendamento = novoHorario;

            ctx.SaveChanges();

            return agendamento;
        }
    }
}