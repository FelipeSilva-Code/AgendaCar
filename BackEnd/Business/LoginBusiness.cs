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

        Database.LoginDatabase db = new Database.LoginDatabase();

        Validador.ValidadorSituacoes validadorSituacoes = new Validador.ValidadorSituacoes();

        public Models.TbLogin Logar(Models.TbLogin login)
        {
            return this.ValidarLogin(login);
        }

        public Models.TbLogin ValidarLogin(Models.TbLogin login)
        {
            if(string.IsNullOrEmpty(login.DsSenha))
                throw new ArgumentException("A senha é obrigatória");

            validadorSituacoes.ValidarEmail(login.DsEmail);

            if (db.ValidarLogin(login) == null)
                throw new ArgumentException("Usúario não encontrado");

            return db.ValidarLogin(login);
        }

    }
}