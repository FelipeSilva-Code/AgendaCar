using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using BackEnd.Business;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EsqueceuSenhaController : ControllerBase
    {
        Business.EsqueceuSenhaBusiness business = new Business.EsqueceuSenhaBusiness();
        Utils.EsqueceuSenhaConversor conversor = new Utils.EsqueceuSenhaConversor();

        private readonly ILogger<EsqueceuSenhaController> _logger;
        private readonly IMailer _mailer;

        public EsqueceuSenhaController(ILogger<EsqueceuSenhaController> logger, IMailer mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }
       
        [HttpGet]
        public ActionResult<Models.Response.InformacoesContaUsuarioResponse> ProcurarContaUsuario (string email)
        {

            try
            {
                Models.TbLogin login = business.PegarLoginUsuario(email);


                if (login.DsPerfil == "Cliente")
                {
                    int idLogin = login.IdLogin;
                    Models.TbCliente cliente = business.RetornarCliente(idLogin);
                    Models.Response.InformacoesContaUsuarioResponse infoResponse = new Models.Response.InformacoesContaUsuarioResponse();
                    return conversor.ParaInfoContaResponse(cliente);
                }

                else
                {
                    int idLogin = login.IdLogin;
                    Models.TbFuncionario funcionario = business.RetornarFuncionario(idLogin);
                    Models.Response.InformacoesContaUsuarioResponse infoResponse = new Models.Response.InformacoesContaUsuarioResponse();
                    return conversor.ParaInfoContaResponse(funcionario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest (new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }      
        }

        [HttpPost]
        public async Task<ActionResult<long>> EnviarEmail (string email)
        {
            try
            {
                long codigo = business.GerarCodigo();

                string corpo = "Olá. O código para a troca de senha é:" + codigo;

                await _mailer.EnviarEmailAsync(email, "Cadastro no AgendaCar", corpo);

                return codigo;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        } 

        [HttpPut("{idUsuario}")]
        public ActionResult<Models.Response.SucessoResponse> AlterarSenha (Models.Request.AlterarSenhaRequest alterarSenhaRequest, int idUsuario)
        {
            try
            {
                
                business.ValidarSenha(alterarSenhaRequest.NovaSenha1, alterarSenhaRequest.NovaSenha2, idUsuario);
                business.AlterarSenha(alterarSenhaRequest.NovaSenha1, alterarSenhaRequest.NovaSenha2, idUsuario);

                return new Models.Response.SucessoResponse(200, "Senha alterada com sucesso.");

            
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