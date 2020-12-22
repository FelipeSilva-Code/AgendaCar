using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class LoginDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();

        public Models.TbLogin ValidarLogin(Models.TbLogin login)
        {
            Models.TbLogin tbLogin = ctx.TbLogin.FirstOrDefault(x => x.DsEmail == login.DsEmail 
                                                                && x.DsSenha == login.DsSenha);
            if (tbLogin != null)
            {
                tbLogin.DtUltimoLogin = DateTime.Now;
                ctx.SaveChanges();
            }

            return tbLogin;
        }
        
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

        public string RetornarFotoDoUsuario(Models.TbLogin login)
        {
            Models.TbCliente cliente = ctx.TbCliente.FirstOrDefault(x => x.IdLogin == login.IdLogin);
            if (cliente != null)
                return cliente.DsFoto;
            else
            {
                Models.TbFuncionario funcionario = ctx.TbFuncionario.FirstOrDefault(x => x.IdLogin == login.IdLogin);
                return funcionario.DsFoto;
            }

        }

    
    }
}