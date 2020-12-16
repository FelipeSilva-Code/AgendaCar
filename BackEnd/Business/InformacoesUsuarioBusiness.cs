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
        public Models.TbCliente PegarInformacoesUsuario(int? idUsuario)
        {
            if(idUsuario == 0 || idUsuario == null)
                throw new ArgumentException("Ocorreu um erro. Tente novamente mais tarde.");

            return db.PegarInformacoesUsuario(idUsuario);

        }

        public void AlterarInformacoesUsuario (Models.TbLogin login, Models.TbCliente cliente)
        {
            validadorInformacoes.GerenciarValidacoesAlterarDadosUsuario(login, cliente);

            db.AlterarInformacoes(login, cliente);
        }
    }
}