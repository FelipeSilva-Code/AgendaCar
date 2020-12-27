using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class AlteracaoDeSituacaoDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        public List<Models.TbAgendamento> VerEsperandoAceitacao()
        {
            List<Models.TbAgendamento> agendamentos =
                          ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                           .Include(x => x.IdCarroNavigation)
                                           .Include(x => x.IdFuncionarioNavigation)
                                           .ToList();


            return agendamentos;
        }

        public void MudarSituacao(int idAgendamento, string situacao)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == idAgendamento);

            agendamento.DsSituacao =situacao;

            ctx.SaveChanges();

            this.ColocarCarroComoDisponivel(idAgendamento); ;
        }

        public void ColocarCarroComoDisponivel(int idAgendamento)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.Include(x => x.IdCarroNavigation).FirstOrDefault(x => x.IdAgendamento == idAgendamento);

            agendamento.IdCarroNavigation.QtdDisponivel ++;

            ctx.SaveChanges();
        }
    }
}