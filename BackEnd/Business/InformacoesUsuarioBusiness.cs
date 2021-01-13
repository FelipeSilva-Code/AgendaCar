using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class InformacoesUsuarioBusiness
    {
        Database.InformacoesUsuarioDatabase db = new Database.InformacoesUsuarioDatabase();
        Validador.ValidadorInformacoes validadorInformacoes = new Validador.ValidadorInformacoes();
        public Models.TbCliente PegarInformacoesCliente(int? idCliente)
        {
            if(idCliente == 0 || idCliente == null)
                throw new ArgumentException("Ocorreu um erro. Tente novamente mais tarde.");

            return db.PegarInformacoesCliente(idCliente);

        }

        public void AlterarInformacoesCliente (Models.TbLogin login, Models.TbCliente cliente)
        {
            validadorInformacoes.GerenciarValidacoesAlterarDadosCliente(login, cliente);

            db.AlterarInformacoesCliente(login, cliente);
        }

        public void VerSeASenhaAtualEstaCertaCliente(string senhaPassada, int idUsuario)
        {
            if(!db.VerSeASenhaAtualEstaCertaCliente(senhaPassada, idUsuario))
                throw new ArgumentException("A senha atual está incorreta.");
        }

        public void AlterarSenhaCliente (string novaSenha, int idUsario)
        {
            validadorInformacoes.ValidarForcaDaSenha(novaSenha);

            db.AlterarSenhaCliente(novaSenha, idUsario);
        }



        // Funcionario
        public Models.TbFuncionario PegarInformacoesFuncionario(int? idFuncionario)
        {
            if (idFuncionario == 0 || idFuncionario == null)
                throw new ArgumentException("Ocorreu um erro. Tente novamente mais tarde.");

            return db.PegarInformacoesFuncionario(idFuncionario);

        }
        public void AlterarInformacoesFuncionario(Models.TbLogin login, Models.TbFuncionario funcionario)
        {
            validadorInformacoes.GerenciarValidacoesAlterarDadosFuncionario(login, funcionario);

            db.AlterarInformacoesFuncionario(login, funcionario);
        }

        public void VerSeASenhaAtualEstaCertaFuncionario(string senhaPassada, int idUsuario)
        {
            if (!db.VerSeASenhaAtualEstaCertaFuncionario(senhaPassada, idUsuario))
                throw new ArgumentException("A senha atual está incorreta.");
        }

        public void AlterarSenhaFuncionario(string novaSenha, int idUsario)
        {
            validadorInformacoes.ValidarForcaDaSenha(novaSenha);

            db.AlterarSenhaFuncionario(novaSenha, idUsario);
        }     

    }
}