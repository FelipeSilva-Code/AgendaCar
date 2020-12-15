using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class CadastroClienteConversor
    {
        public Models.TbLogin ParaTbLogin (Models.Request.CadastroUsuario request)
        {
            Models.TbLogin login = new Models.TbLogin();
            login.DsEmail = request.Email;
            login.DsSenha = request.Senha1;
            login.DsPerfil = "Cliente";

            return login;
        }   

        public Models.TbCliente ParaTbCliente (Models.Request.CadastroUsuario request)
        {
            Models.TbCliente cliente = new Models.TbCliente();
            cliente.DsCnh = request.CNH;
            cliente.DsCpf = request.CPF;
            cliente.DsTelefone = request.Telefone;
            cliente.DtNascimento = request.DataNascimento;
            cliente.NmCliente = request.Nome;
            
            return cliente;
        }

    }
}