using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class CadastroClienteDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();

        public Models.TbLogin GerenciarPostNasTabelas (Models.TbLogin login, Models.TbCliente cliente)
        {
            login = this.AdicionarNaTbLogin(login);
            this.AdicionarNaTbCliente(login.IdLogin, cliente);
            return login;
        }

        public Models.TbLogin AdicionarNaTbLogin (Models.TbLogin login)
        {
            ctx.TbLogin.Add(login);
            ctx.SaveChanges();
            return login;
        }

        public void AdicionarNaTbCliente (int idLogin, Models.TbCliente cliente)
        {
            cliente.IdLogin = idLogin;
            ctx.TbCliente.Add(cliente);
            ctx.SaveChanges();
        }
    }
}