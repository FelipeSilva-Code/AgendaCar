using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class CadastroConversor
    {
        public Models.TbLogin ParaTbLogin (Models.Request.CadastroClienteRequest request)
        {
            Models.TbLogin login = new Models.TbLogin();
            login.DsEmail = request.Email;
            login.DsSenha = request.Senha1;
            login.DsPerfil = "Cliente";

            return login;
        }   

        public Models.TbCliente ParaTbCliente (Models.Request.CadastroClienteRequest request)
        {
            Models.TbCliente cliente = new Models.TbCliente();
            cliente.DsCnh = request.CNH;
            cliente.DsCpf = request.CPF;
            cliente.DsTelefone = request.Telefone;
            cliente.DtNascimento = request.DataNascimento;
            cliente.NmCliente = request.Nome;
            
            return cliente;
        }

        public Models.TbLogin ParaTbLogin(Models.Request.CadastroFuncionarioRequest request)
        {
            Models.TbLogin login = new Models.TbLogin();
            login.DsEmail = request.Email;
            login.DsSenha = request.Senha1;
            login.DsPerfil = "Funcionario";

            return login;
        }

        public Models.TbFuncionario ParaTbFuncionario(Models.Request.CadastroFuncionarioRequest request)
        {
            Models.TbFuncionario funcionario = new Models.TbFuncionario();
            funcionario.DsCarteiraTrabalho = request.CarteiraTrabalho;
            funcionario.DsCpf = request.CPF;
            funcionario.DsTelefone = request.Telefone;
            funcionario.DtNascimento = request.DataNascimento;
            funcionario.NmFuncionario = request.Nome;

            return funcionario;
        }

    }
}