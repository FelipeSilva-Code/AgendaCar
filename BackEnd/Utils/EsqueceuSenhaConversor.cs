using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class EsqueceuSenhaConversor
    {
        
        public Models.Response.InformacoesContaUsuarioResponse ParaInfoContaResponse (Models.TbCliente cliente)
        {
            Models.Response.InformacoesContaUsuarioResponse infoConta = new Models.Response.InformacoesContaUsuarioResponse();

            infoConta.Email = cliente.IdLoginNavigation.DsEmail;
            infoConta.Perfil = cliente.IdLoginNavigation.DsPerfil;
            infoConta.IdLogin = cliente.IdLogin;
            infoConta.IdUsuario = cliente.IdCliente;
            infoConta.NomeImagem = cliente.DsFoto;
            infoConta.NomeUsuario = cliente.NmCliente;

            return infoConta;
        }

        public Models.Response.InformacoesContaUsuarioResponse ParaInfoContaResponse(Models.TbFuncionario funcionario)
        {
            Models.Response.InformacoesContaUsuarioResponse infoConta = new Models.Response.InformacoesContaUsuarioResponse();

            infoConta.Email = funcionario.IdLoginNavigation.DsEmail;
            infoConta.Perfil = funcionario.IdLoginNavigation.DsPerfil;
            infoConta.IdLogin = funcionario.IdLogin;
            infoConta.IdUsuario = funcionario.IdFuncionario;
            infoConta.NomeImagem = funcionario.DsFoto;
            infoConta.NomeUsuario = funcionario.NmFuncionario;
            
            return infoConta;
        }
    }
}