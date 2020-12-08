using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class LoginBusiness
    {

        Database.ValidacoesDatabase db = new Database.ValidacoesDatabase();

        public Models.TbLogin Logar (Models.TbLogin login)
        {
            return this.ValidarLogin(login);
        }

          public Models.TbLogin ValidarLogin(Models.TbLogin login)
        {
            if (login.DsCpf.Length < 11 || login.DsCpf.Length > 11)
                throw new ArgumentException("O CPF deverá conter 11 números");

            if (db.ValidarLogin(login) == null)
                throw new ArgumentException("Usúario não encontrado");

            return db.ValidarLogin(login);
        }
        
    }
}