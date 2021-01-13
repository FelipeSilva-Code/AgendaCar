using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd.Business
{
    public class CadastroFuncionarioBusiness
    {
        Validador.ValidadorInformacoes validadorInformacoes = new Validador.ValidadorInformacoes();
        Database.CadastroFuncionarioDatabase database = new Database.CadastroFuncionarioDatabase();

        public Models.TbLogin CadastrarFuncionario(Models.TbLogin login, Models.TbFuncionario funcionario)
        {
            validadorInformacoes.GerenciarValidacoesCadastroFuncionario(login, funcionario);

            return database.GerenciarPostNasTabelas(login, funcionario);
        }

    }
}