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
        Utils.InformacoesUsuarioConversor conversorInfoUsuario = new Utils.InformacoesUsuarioConversor();
        


        [HttpGet("{idUsuario}")]
        public ActionResult<Models.Response.InformacoesResponse> PegarInformacoesUsuario (int idUsuario)
        {
    
            try
            {
                Models.TbCliente cliente = business.PegarInformacoesUsuario(idUsuario);

                Models.Response.InformacoesResponse informacoesResponse = conversorInfoUsuario.ParaInformacoesResponse(cliente);

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
    }
}