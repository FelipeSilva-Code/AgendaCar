using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class ValidacoesDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();



        public bool ValidarDataAgendamentoParaCliente (DateTime? dataAgendamento, int? Id)
        {
            List<Models.TbAgendamento> agendamento = ctx.TbAgendamento.Where( x => x.IdCliente == Id && x.DtAgendamento.Value.Date == dataAgendamento.Value.Date).ToList();
            foreach(Models.TbAgendamento item in agendamento)
            {
                if(dataAgendamento < item.DtAgendamento.Value.AddHours(1) && dataAgendamento > item.DtAgendamento.Value.AddHours(-1) )
                   return true;
            }
            return false;
        }

        public bool ValidarDataAgendamentoParaFuncionarioRemarcar(DateTime? dataAgendamento, int? Id)
        {
            List<Models.TbAgendamento> agendamento = ctx.TbAgendamento.Where(x => x.IdFuncionario == Id && x.DtAgendamento.Value.Date == dataAgendamento.Value.Date).ToList();
            foreach (Models.TbAgendamento item in agendamento)
            {
                if (dataAgendamento < item.DtAgendamento.Value.AddHours(1) && dataAgendamento > item.DtAgendamento.Value.AddHours(-1))
                    return true;
            }
            return false;
        }

        public bool ValidarDataAgendamentoParaFuncionario (int? idFuncionario, int idAgendamento)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == idAgendamento);

            List<Models.TbAgendamento> agendamentosNoDia = ctx.TbAgendamento.Where(x => x.IdFuncionario == idFuncionario && x.DtAgendamento.Value.Date == agendamento.DtAgendamento.Value.Date).ToList();
           
            foreach (Models.TbAgendamento item in agendamentosNoDia)
            {
                if (agendamento.DtAgendamento < item.DtAgendamento.Value.AddHours(1) && agendamento.DtAgendamento > item.DtAgendamento.Value.AddHours(-1))
                    return true;
            }
           
            return false;
        }

        public bool ValidarCarroDoAgendamento (int? IdDoCarro)
        {
            Models.TbCarro carro = ctx.TbCarro.FirstOrDefault(x => x.IdCarro == IdDoCarro);
            return carro.BtDisponivel == false;
        }

        public bool VerSeEmailJaEstaCadastrado (string email)
        {
            bool x = ctx.TbLogin.Any(x => x.DsEmail == email);

            return x;
        }

        

    }
}