using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class GeralDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
       
        public int RetornarIdDoUsuario(Models.TbLogin login)
        {
            Models.TbCliente cliente = ctx.TbCliente.FirstOrDefault(x => x.IdLogin == login.IdLogin);
            if (cliente != null)
                return cliente.IdCliente;
            else
            {
                Models.TbFuncionario funcionario = ctx.TbFuncionario.FirstOrDefault(x => x.IdLogin == login.IdLogin);
                return funcionario.IdFuncionario;
            }
        }

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