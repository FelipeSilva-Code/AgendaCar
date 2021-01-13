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

    public class CadastroClienteController : ControllerBase
    {
        Business.CadastroClienteBusiness business = new Business.CadastroClienteBusiness();
        Business.GerenciadorFotoBusiness gerenciadorFoto = new Business.GerenciadorFotoBusiness();
        Business.Validador.ValidadorInformacoes validador = new Business.Validador.ValidadorInformacoes();
        Utils.CadastroConversor cadastroConversor = new Utils.CadastroConversor();
        Utils.LoginConversor loginConversor = new Utils.LoginConversor();

        private readonly ILogger<CadastroClienteController> _logger;
        private readonly IMailer _mailer;

        public CadastroClienteController(ILogger<CadastroClienteController> logger, IMailer mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }

        [HttpPost]
        public async Task<ActionResult<Models.Response.LoginResponse>> CadastrarCliente([FromForm] Models.Request.CadastroClienteRequest cadastroCliente)
        {
            try
            {
                validador.VerSeSenhasSaoIguais(cadastroCliente.Senha1, cadastroCliente.Senha2);

                Models.TbLogin login = cadastroConversor.ParaTbLogin(cadastroCliente);
                Models.TbCliente cliente = cadastroConversor.ParaTbCliente(cadastroCliente);

                if(cadastroCliente.ImagemUsuario != null)
                    cliente.DsFoto = gerenciadorFoto.GerarNovoNome(cadastroCliente.ImagemUsuario.FileName);
                
                else
                    cliente.DsFoto = "user.png";

                login = business.CadastrarCliente(login, cliente);

                if (cadastroCliente.ImagemUsuario != null)
                    gerenciadorFoto.SalvarFoto(cliente.DsFoto, cadastroCliente.ImagemUsuario);

                Models.Response.LoginResponse loginResponse = loginConversor.ParaLoginResponse(login);

                string corpo = $"Olá {cliente.NmCliente}. Nós da AgendaCar ficamos muito felizes por você se juntar a nós. Que tal agendar seu primeiro Test Drive?";

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