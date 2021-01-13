using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class InformacoesUsuarioConversor
    {
        public Models.Response.InformacoesClienteResponse ParaInformacoesResponse (Models.TbCliente cliente)
        {
            Models.Response.InformacoesClienteResponse informacoesResponse = new Models.Response.InformacoesClienteResponse();

            informacoesResponse.CNH = cliente.DsCnh;
            informacoesResponse.CPF = cliente.DsCpf;
            informacoesResponse.DataNascimento = cliente.DtNascimento;
            informacoesResponse.Email = cliente.IdLoginNavigation.DsEmail;
            informacoesResponse.ImagemUsuario = cliente.DsFoto;
            informacoesResponse.Nome = cliente.NmCliente;
            informacoesResponse.Senha = cliente.IdLoginNavigation.DsSenha;
            informacoesResponse.Telefone = cliente.DsTelefone;
            informacoesResponse.IdUsuario = cliente.IdLogin;

            return informacoesResponse;
        }

        public Models.TbLogin ParaTbLogin(Models.Request.InformacoesClienteRequest informacoesRequest)
        {
            Models.TbLogin login = new Models.TbLogin();

            login.DsEmail = informacoesRequest.Email;
            login.DsSenha = informacoesRequest.Senha;
            
            return login;
        }

        public Models.TbCliente ParaTbCliente (Models.Request.InformacoesClienteRequest informacoesRequest, int idUsuario)
        {
            Models.TbCliente cliente = new Models.TbCliente();

            cliente.IdCliente = idUsuario;
            cliente.DsCnh = informacoesRequest.CNH;
            cliente.DsCpf = informacoesRequest.CPF;
            cliente.DsTelefone = informacoesRequest.Telefone;
            cliente.DtNascimento = informacoesRequest.DataNascimento;
            cliente.NmCliente = informacoesRequest.Nome;
            
            return cliente;
        }


        // Funcionário
        public Models.Response.InformacoesFuncionarioResponse ParaInformacoesResponse(Models.TbFuncionario funcionario)
        {
            Models.Response.InformacoesFuncionarioResponse informacoesResponse = new Models.Response.InformacoesFuncionarioResponse();

            informacoesResponse.CarteiraTrabalho = funcionario.DsCarteiraTrabalho;
            informacoesResponse.CPF = funcionario.DsCpf;
            informacoesResponse.DataNascimento = funcionario.DtNascimento;
            informacoesResponse.Email = funcionario.IdLoginNavigation.DsEmail;
            informacoesResponse.ImagemUsuario = funcionario.DsFoto;
            informacoesResponse.Nome = funcionario.NmFuncionario;
            informacoesResponse.Senha = funcionario.IdLoginNavigation.DsSenha;
            informacoesResponse.Telefone = funcionario.DsTelefone;
            informacoesResponse.IdUsuario = funcionario.IdLogin;

            return informacoesResponse;
        }

        public Models.TbLogin ParaTbLogin(Models.Request.InformacoesFuncionarioRequest informacoesRequest)
        {
            Models.TbLogin login = new Models.TbLogin();

            login.DsEmail = informacoesRequest.Email;
            login.DsSenha = informacoesRequest.Senha;

            return login;
        }

        public Models.TbFuncionario ParaTbFuncionario(Models.Request.InformacoesFuncionarioRequest informacoesRequest, int idUsuario)
        {
            Models.TbFuncionario funcionario = new Models.TbFuncionario();

            funcionario.IdFuncionario = idUsuario;
            funcionario.DsCarteiraTrabalho = informacoesRequest.CarteiraTrabalho;
            funcionario.DsCpf = informacoesRequest.CPF;
            funcionario.DsTelefone = informacoesRequest.Telefone;
            funcionario.DtNascimento = informacoesRequest.DataNascimento;
            funcionario.NmFuncionario = informacoesRequest.Nome;

            return funcionario;
        }

    }
}