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
        


        [HttpGet("{idUsuario}")]
        public ActionResult<Models.Response.InformacoesClienteResponse> PegarInformacoesUsuario (int idUsuario)
        {
    
            try
            {
                Models.TbCliente cliente = business.PegarInformacoesUsuario(idUsuario);

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
        public ActionResult<Models.Response.SucessoResponse> AlterarInformacoesUsuario ([FromForm] Models.Request.InformacoesRequest  informacoesRequest, int idUsuario)
        {
            try
            {
                Models.TbLogin login = conversorInfoUsuario.ParaTbLogin(informacoesRequest);
                Models.TbCliente cliente = conversorInfoUsuario.ParaTbCliente(informacoesRequest, idUsuario);

                if (informacoesRequest.ImagemUsuario != null)
                    cliente.DsFoto = gerenciadorFotoBusiness.GerarNovoNome(informacoesRequest.ImagemUsuario.FileName);

                business.AlterarInformacoesUsuario(login, cliente);

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
                business.VerSeASenhaAtualEstaCerta(senhaPassada, idUsuario);

                validador.VerSeSenhasSaoIguais(request.NovaSenha1, request.NovaSenha2);

                string novaSenha = request.NovaSenha1;

                business.AlterarSenha(novaSenha, idUsuario);

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