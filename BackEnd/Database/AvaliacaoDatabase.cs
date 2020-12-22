using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class AvaliacaoDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        public void AvaliarTestDriver(int id, Models.Request.AvaliacaoRequest nota)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == id);

            agendamento.NrAvaliacao = nota.Nota;

            ctx.SaveChanges();
        }
    }
}