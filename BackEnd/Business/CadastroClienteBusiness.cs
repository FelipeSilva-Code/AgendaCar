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
        Validador.ValidadorCadastro validadorCadastro = new Validador.ValidadorCadastro();

        public void VerSeSenhasSaoIguais(string senha1, string senha2)
        {
            if (senha1 != senha2)
                throw new ArgumentException("As senhas são diferentes.");
        }

        public Models.TbLogin CadastrarCliente(Models.TbLogin login, Models.TbCliente cliente)
        {
            validadorCadastro.GerenciarValidacoesCadastroCliente(login, cliente);
            
            return null;
        }

      
    }
}