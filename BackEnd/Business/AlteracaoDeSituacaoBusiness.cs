using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Business
{
    public class AlteracaoDeSituacaoBusiness
    {
        Database.AlteracaoDeSituacaoDatabase db = new Database.AlteracaoDeSituacaoDatabase();
        public List<Models.TbAgendamento> VerEsperandoAceitacao()
        {
            return db.VerEsperandoAceitacao();
        }

        public void MudarSituacao(int idAgendamento, string situacao)
        {
            db.MudarSituacao(idAgendamento, situacao);
        }
    }
}