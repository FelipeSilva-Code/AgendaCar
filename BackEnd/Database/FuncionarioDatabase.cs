using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Database
{
    public class FuncionarioDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        Database.GeralDatabase dbGeral = new Database.GeralDatabase();

        public List<Models.TbAgendamento> RetornarAgendadosFuncionario (int idFuncionario)
        {
            List<Models.TbAgendamento> agendamento = ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                                                       .Include(x => x.IdCarroNavigation)
                                                                       .Include(x => x.IdFuncionarioNavigation)   
                                                                       .ToList();

           return agendamento.Where( x => x.IdFuncionario == idFuncionario).ToList();                                                            
                                                                 
        }

        public void MudarSituacao (int idAgendamento ,Models.Request.MudarSituacao situacao)
        {
            Models.TbAgendamento agendamento = ctx.TbAgendamento.FirstOrDefault( x => x.IdAgendamento == idAgendamento);

            agendamento.DsSituacao = situacao.Situacao;

            ctx.SaveChanges();
        }

   
        public Models.TbAgendamento AceitarAgendamento(int idFuncionario, int idAgendamento)
        {
           Models.TbAgendamento agendamento = ctx.TbAgendamento.Include(x => x.IdCarroNavigation)
                                              .Include( x => x.IdFuncionarioNavigation)
                                              .Include( x => x.IdClienteNavigation)
                                              .FirstOrDefault( x => x.IdAgendamento == idAgendamento);                                                             


           agendamento.IdFuncionario = idFuncionario;
           agendamento.DsSituacao = "Aprovado";
           ctx.SaveChanges();

           return agendamento;
        }
        public List<Models.TbAgendamento> VerEsperandoAceitacao()
        {
             List<Models.TbAgendamento> agendamentos = ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                                                        .Include(x => x.IdCarroNavigation)
                                                                        .Include(x => x.IdFuncionarioNavigation)
                                                                        .ToList();

             agendamentos = dbGeral.AlterarSituacaoSeNinguemAceitar(agendamentos);
           
             return agendamentos;                                                          
        }
    }
}