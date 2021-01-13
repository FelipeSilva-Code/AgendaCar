using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InformacoesUsuarioController : ControllerBase
    {
        Business.InformacoesUsuarioBusiness business = new Business.InformacoesUsuarioBusiness();
        Business.GerenciadorFotoBusiness gerenciadorFotoBusiness = new Business.GerenciadorFotoBusiness();
        Business.Validador.ValidadorInformacoes validador = new Business.Validador.ValidadorInformacoes();
        Utils.InformacoesUsuarioConversor conversorInfoUsuario = new Utils.InformacoesUsuarioConversor();
        

        //  Somentes Infos do Cliente
        [HttpGet("{idCliente}")]
        public ActionResult<Models.Response.InformacoesClienteResponse> PegarInformacoesCliente (int idCliente)
        {
    
            try
            {
                Models.TbCliente cliente = business.PegarInformacoesCliente(idCliente);

                Models.Response.InformacoesClienteResponse informacoesResponse = conversorInfoUsuario.ParaInformacoesResponse(cliente);

                return informacoesResponse;         
            }
            catch (System.Exception ex)
            {
                return BadRequest (new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpPut("{idUsuario}")]
        public ActionResult<Models.Response.SucessoResponse> AlterarInformacoesCliente ([FromForm] Models.Request.InformacoesClienteRequest  informacoesRequest, int idUsuario)
        {
            try
            {
                Models.TbLogin login = conversorInfoUsuario.ParaTbLogin(informacoesRequest);
                Models.TbCliente cliente = conversorInfoUsuario.ParaTbCliente(informacoesRequest, idUsuario);

                if (informacoesRequest.ImagemUsuario != null)
                    cliente.DsFoto = gerenciadorFotoBusiness.GerarNovoNome(informacoesRequest.ImagemUsuario.FileName);

                business.AlterarInformacoesCliente(login, cliente);

                if (informacoesRequest.ImagemUsuario != null)
                    gerenciadorFotoBusiness.SalvarFoto(cliente.DsFoto, informacoesRequest.ImagemUsuario);

                return new Models.Response.SucessoResponse(200, "Alterado Com Sucesso.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
       
        }

        [HttpPut("AlterarSenha/{idUsuario}")]
        public ActionResult<Models.Response.SucessoResponse> AlterarSenha (Models.Request.AlterarSenhaRequest request, int idUsuario)
        {
            try
            {
                string senhaPassada = request.SenhaAtual;
                business.VerSeASenhaAtualEstaCertaCliente(senhaPassada, idUsuario);

                validador.VerSeSenhasSaoIguais(request.NovaSenha1, request.NovaSenha2);

                string novaSenha = request.NovaSenha1;

                business.AlterarSenhaCliente(novaSenha, idUsuario);

                return new Models.Response.SucessoResponse(200, "Senha alterada.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }


        // Somente Infos Funcionário
        [HttpGet("infoFuncionario/{idFuncionario}")]
        public ActionResult<Models.Response.InformacoesFuncionarioResponse> PegarInformacoesFuncionario(int idFuncionario)
        {

            try
            {
                Models.TbFuncionario funcionario = business.PegarInformacoesFuncionario(idFuncionario);

                Models.Response.InformacoesFuncionarioResponse informacoesResponse = conversorInfoUsuario.ParaInformacoesResponse(funcionario);

                return informacoesResponse;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpPut("alterarInfoFuncionario/{idUsuario}")]
        public ActionResult<Models.Response.SucessoResponse> AlterarInformacoesFuncionario([FromForm] Models.Request.InformacoesFuncionarioRequest informacoesRequest, int idUsuario)
        {
            try
            {
                Models.TbLogin login = conversorInfoUsuario.ParaTbLogin(informacoesRequest);
                Models.TbFuncionario funcionario = conversorInfoUsuario.ParaTbFuncionario(informacoesRequest, idUsuario);

                if (informacoesRequest.ImagemUsuario != null)
                    funcionario.DsFoto = gerenciadorFotoBusiness.GerarNovoNome(informacoesRequest.ImagemUsuario.FileName);

                business.AlterarInformacoesFuncionario(login, funcionario);

                if (informacoesRequest.ImagemUsuario != null)
                    gerenciadorFotoBusiness.SalvarFoto(funcionario.DsFoto, informacoesRequest.ImagemUsuario);

                return new Models.Response.SucessoResponse(200, "Alterado Com Sucesso.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }

        }

        [HttpPut("AlterarSenha/Funcionario/{idUsuario}")]
        public ActionResult<Models.Response.SucessoResponse> AlterarSenhaFuncionario(Models.Request.AlterarSenhaRequest request, int idUsuario)
        {
            try
            {
                string senhaPassada = request.SenhaAtual;
                business.VerSeASenhaAtualEstaCertaFuncionario(senhaPassada, idUsuario);

                validador.VerSeSenhasSaoIguais(request.NovaSenha1, request.NovaSenha2);

                string novaSenha = request.NovaSenha1;

                business.AlterarSenhaFuncionario(novaSenha, idUsuario);

                return new Models.Response.SucessoResponse(200, "Senha alterada.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

    }
}