using System;
using System.Threading.Tasks;
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

       
        public Models.TbLogin ValidarLogin (Models.TbLogin login)
        {
            Models.TbLogin tbLogin = ctx.TbLogin.FirstOrDefault(x => x.DsEmail == login.DsEmail  && x.DsSenha == login.DsSenha );
            if(tbLogin != null)
            {
                tbLogin.DtUltimoLogin = DateTime.Now;
                ctx.SaveChanges();
            }

            return tbLogin;
        }     

        public bool ValidarDataAgendamento (DateTime? dataAgendamento, int? Id)
        {
            List<Models.TbAgendamento> agendamento = ctx.TbAgendamento.Where( x => x.IdCliente == Id).ToList();
            foreach(Models.TbAgendamento item in agendamento)
            {
                if( item.DtAgendamento == dataAgendamento)
                   return true;
            }
            return false;
        }

        public bool ValidarCarroDoAgendamento (int? IdDoCarro)
        {
            Models.TbCarro carro = ctx.TbCarro.FirstOrDefault(x => x.IdCarro == IdDoCarro);
            return carro.BtDisponivel == false;
        }

        

    }
}