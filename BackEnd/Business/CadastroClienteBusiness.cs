using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Business
{
    public class CadastroClienteBusiness
    {
        Validador.ValidadorInformacoes validadorInformacoes= new Validador.ValidadorInformacoes();
        Database.CadastroClienteDatabase database = new Database.CadastroClienteDatabase();

        public Models.TbLogin CadastrarCliente(Models.TbLogin login, Models.TbCliente cliente)
        {
            validadorInformacoes.GerenciarValidacoesCadastroCliente(login, cliente);
            
            return database.GerenciarPostNasTabelas(login, cliente);
        }

      
    }
}