using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class EsqueceuSenhaDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        
        public Models.TbLogin PegarLoginUsuario(string email)
        {
            Models.TbLogin login = ctx.TbLogin.FirstOrDefault(x => x.DsEmail == email);
            
            return login;
        }

        public Models.TbLogin PegarLoginUsuario (int idLogin)
        {
            Models.TbLogin login = ctx.TbLogin.FirstOrDefault(x => x.IdLogin == idLogin);

            return login;
        }


        public Models.TbCliente RetornarCliente(int idLogin)
        {
            Models.TbCliente cliente = ctx.TbCliente.Include(x => x.IdLoginNavigation)
                                            .FirstOrDefault(x => x.IdLogin == idLogin);

            return cliente;
        }

        public Models.TbFuncionario RetornarFuncionario(int idLogin)
        {
            Models.TbFuncionario funcionario = ctx.TbFuncionario.Include(x => x.IdLoginNavigation)
                                                        .FirstOrDefault(x => x.IdLogin == idLogin);

            return funcionario;
        }

        public bool VerSenhaAtual(string novaSenha, int idLogin)
        {
           Models.TbLogin login = this.PegarLoginUsuario(idLogin);

           return login.DsSenha == novaSenha;

        }
        
        public void AlterarSenha (string novaSenha, int idLogin)
        {
            Models.TbLogin login = this.PegarLoginUsuario(idLogin);
            login.DsSenha = novaSenha;

            ctx.SaveChanges();
        }

    }
}