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
        public Models.Response.InformacoesResponse ParaInformacoesResponse (Models.TbCliente cliente)
        {
            Models.Response.InformacoesResponse informacoesResponse = new Models.Response.InformacoesResponse();

            informacoesResponse.CNH = cliente.DsCnh;
            informacoesResponse.CPF = cliente.DsCpf;
            informacoesResponse.DataNascimento = cliente.DtNascimento;
            informacoesResponse.Email = cliente.IdLoginNavigation.DsEmail;
            informacoesResponse.ImagemUsuario = cliente.DsFoto;
            informacoesResponse.Nome = cliente.NmCliente;
            informacoesResponse.Senha = cliente.IdLoginNavigation.DsSenha;
            informacoesResponse.Telefone = cliente.DsTelefone;

            return informacoesResponse;
        }
    }
}