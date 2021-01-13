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
    
    public class CadastroFuncionarioController : ControllerBase
    {
        Business.CadastroFuncionarioBusiness business = new Business.CadastroFuncionarioBusiness();
        Business.GerenciadorFotoBusiness gerenciadorFoto = new Business.GerenciadorFotoBusiness();
        Business.Validador.ValidadorInformacoes validador = new Business.Validador.ValidadorInformacoes();
        Utils.CadastroConversor cadastroConversor = new Utils.CadastroConversor();
        Utils.LoginConversor loginConversor = new Utils.LoginConversor();


        private readonly ILogger<CadastroFuncionarioController> _logger;
        private readonly IMailer _mailer;

        public CadastroFuncionarioController(ILogger<CadastroFuncionarioController> logger, IMailer mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }

        [HttpPost]
        public async Task<ActionResult<Models.Response.LoginResponse>> CadastrarFuncionario([FromForm] Models.Request.CadastroFuncionarioRequest cadastroFuncionario)
        {
            try
            {
                validador.VerSeSenhasSaoIguais(cadastroFuncionario.Senha1, cadastroFuncionario.Senha2);

                Models.TbLogin login = cadastroConversor.ParaTbLogin(cadastroFuncionario);
                Models.TbFuncionario funcionario = cadastroConversor.ParaTbFuncionario(cadastroFuncionario);

                if (cadastroFuncionario.ImagemUsuario != null)
                    funcionario.DsFoto = gerenciadorFoto.GerarNovoNome(cadastroFuncionario.ImagemUsuario.FileName);

                else
                    funcionario.DsFoto = "user.png";

                login = business.CadastrarFuncionario(login, funcionario);

                if (cadastroFuncionario.ImagemUsuario != null)
                    gerenciadorFoto.SalvarFoto(funcionario.DsFoto, cadastroFuncionario.ImagemUsuario);

                Models.Response.LoginResponse loginResponse = loginConversor.ParaLoginResponse(login);

                string corpo = $"Olá {funcionario.NmFuncionario}. Agora você faz parte da familía AgendaCar.";

                await _mailer.EnviarEmailAsync(login.DsEmail, "Cadastro no AgendaCar", corpo);

                return loginResponse;
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