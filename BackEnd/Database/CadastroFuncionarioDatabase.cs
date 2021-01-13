using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class CadastroFuncionarioDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();

        public Models.TbLogin GerenciarPostNasTabelas(Models.TbLogin login, Models.TbFuncionario funcionario)
        {
            login = this.AdicionarNaTbLogin(login);
            this.AdicionarNaTbFuncionario(login.IdLogin, funcionario);
            return login;
        }

        public Models.TbLogin AdicionarNaTbLogin(Models.TbLogin login)
        {
            ctx.TbLogin.Add(login);
            ctx.SaveChanges();
            return login;
        }

        public void AdicionarNaTbFuncionario(int idLogin, Models.TbFuncionario funcionario)
        {
            funcionario.IdLogin = idLogin;
            ctx.TbFuncionario.Add(funcionario);
            ctx.SaveChanges();
        }
    }
}