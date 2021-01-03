using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Utils
{
    public class ProcuraPorUsuarioConversor
    {
        InformacoesUsuarioConversor informacoesUsuarioConversor = new InformacoesUsuarioConversor();
        
        public List<Models.Response.InformacoesClienteResponse> ParaInfoCliente (List<Models.TbCliente> clientes)
        {
            List<Models.Response.InformacoesClienteResponse> response = new List<Models.Response.InformacoesClienteResponse>();

            foreach(Models.TbCliente item in clientes)
            {
                Models.Response.InformacoesClienteResponse infoResponse = informacoesUsuarioConversor.ParaInformacoesResponse(item);
                response.Add(infoResponse);
            }

            return response;
        }  

        public List<Models.Response.InformacoesFuncionarioResponse> ParaInfoFuncionario (List<Models.TbFuncionario> funcionarios)
        {
            List<Models.Response.InformacoesFuncionarioResponse> response = new List<Models.Response.InformacoesFuncionarioResponse>();

            foreach(Models.TbFuncionario item in funcionarios)
            {
                Models.Response.InformacoesFuncionarioResponse infoFuncionario = new Models.Response.InformacoesFuncionarioResponse();

                infoFuncionario.CarteiraTrabalho = item.DsCarteiraTrabalho;
                infoFuncionario.CPF = item.DsCpf;
                infoFuncionario.DataNascimento = item.DtNascimento;
                infoFuncionario.Email = item.IdLoginNavigation.DsEmail;
                infoFuncionario.ImagemUsuario = item.DsFoto;
                infoFuncionario.Nome = item.NmFuncionario;
                infoFuncionario.Senha = item.IdLoginNavigation.DsSenha;
                infoFuncionario.Telefone = item.DsTelefone;
                
                response.Add(infoFuncionario);
            }

            return response;
        }


    }
}