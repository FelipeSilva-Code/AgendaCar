using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class VerAgendamentosDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
       
        public List<Models.TbAgendamento> ListarAgendadosCliente(int idcliente)
        {
            List<Models.TbAgendamento> agendamento = new List<Models.TbAgendamento>();
            agendamento = ctx.TbAgendamento.Where(x => x.IdCliente == idcliente)
                                           .Include(x => x.IdCarroNavigation)
                                           .Include(x => x.IdClienteNavigation)
                                           .Include(x => x.IdFuncionarioNavigation).ToList();

            return this.AlterarSituacaoSeNinguemAceitar(agendamento);
        }
       
        public List<Models.TbAgendamento> RetornarAgendadosFuncionario(int idFuncionario)
        {
            List<Models.TbAgendamento> agendamento = ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                                                       .Include(x => x.IdCarroNavigation)
                                                                       .Include(x => x.IdFuncionarioNavigation)
                                                                       .ToList();

            agendamento = agendamento.Where(x => x.IdFuncionario == idFuncionario).ToList();

            return this.AlterarSituacaoSeNinguemAceitar(agendamento);

        }

        public List<Models.TbAgendamento> PegarTodosAgendamentos()
        {
            List<Models.TbAgendamento> agendamentos = ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                                                        .Include(x => x.IdCarroNavigation)
                                                                        .Include(x => x.IdFuncionarioNavigation)
                                                                        .ToList();

            return agendamentos;                                                           
        }

        
        //Altera a situação dos agendamentos ao logar no sistema
        public List<Models.TbAgendamento> AlterarSituacaoSeNinguemAceitar(List<Models.TbAgendamento> agendamentos)
        {

            foreach (Models.TbAgendamento item in agendamentos)
            {
                if (item.DtAgendamento <= DateTime.Now
                && item.DsSituacao == "Pendente")
                {
                    item.DsSituacao = "Não Aprovado";
                    ctx.SaveChanges();
                }
            }

            return agendamentos;

        }
    }
}