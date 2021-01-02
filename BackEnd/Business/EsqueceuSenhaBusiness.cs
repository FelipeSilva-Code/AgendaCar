using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Business
{
    public class EsqueceuSenhaBusiness
    {
        Database.EsqueceuSenhaDatabase db = new Database.EsqueceuSenhaDatabase();
        Validador.ValidadorSituacoes validadorSituacoes = new Validador.ValidadorSituacoes();
        Validador.ValidadorInformacoes validadorInformacoes = new Validador.ValidadorInformacoes();

        public Models.TbLogin PegarLoginUsuario (string email)
        {
            validadorSituacoes.ValidarEmail(email);

            Models.TbLogin login = db.PegarLoginUsuario(email);

            if (login == null)
                throw new ArgumentException("Nenhum registro encontrado.");

            return login;    
        }

        public Models.TbCliente RetornarCliente (int idLogin)
        {
            return db.RetornarCliente(idLogin);
        }

        public Models.TbFuncionario RetornarFuncionario (int idLogin)
        {
            return db.RetornarFuncionario(idLogin);
        }

        public long GerarCodigo()
        {
            Random random = new Random();

            long codigo = random.Next(10000, 99999);

            return codigo;

        }

        public void ValidarSenha (string senha1, string senha2, int idLogin)
        {
            validadorInformacoes.VerSeSenhasSaoIguais(senha1, senha2);
            
            validadorInformacoes.ValidarForcaDaSenha(senha1);
            
            if(db.VerSenhaAtual(senha1, idLogin))
                throw new ArgumentException("A nova senha não pode ser igual a atual");
        }


        public void AlterarSenha (string senha1, string senha2, int idLogin)
        {
            db.AlterarSenha(senha1, idLogin);
        }


    }
}