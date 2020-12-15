using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class FuncionarioBusiness
    {

        Database.FuncionarioDatabase db = new Database.FuncionarioDatabase();
        Business.Validador.ValidadorSituacoes ValidadorSituacoes = new Validador.ValidadorSituacoes();
        Business.Validador.ValidacoesAgendamentoBusiness ValidadodorAgendamento = new Validador.ValidacoesAgendamentoBusiness();

        public List<Models.TbAgendamento> RetornarAgendadosFuncionario (int idFuncionario)
        {
            ValidadorSituacoes.ValidarId(idFuncionario);
            return db.RetornarAgendadosFuncionario(idFuncionario);
        }

         public void MudarSituacao (int idAgendamento, Models.Request.MudarSituacao situacao)
        {
            db.MudarSituacao(idAgendamento, situacao);
        }

        public Models.TbAgendamento AceitarAgendamento(int idFuncionario, int idAgendamento)
        {
            ValidadorSituacoes.ValidarId(idFuncionario);
            ValidadorSituacoes.ValidarId(idAgendamento);
            return db.AceitarAgendamento(idFuncionario, idAgendamento);
        }
        
        public List<Models.TbAgendamento> VerEsperandoAceitacao ()
        {
            return db.VerEsperandoAceitacao();
        }
    }
}