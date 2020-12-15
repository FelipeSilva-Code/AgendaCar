using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CadastroClienteController : ControllerBase
    {
        Business.CadastroClienteBusiness business = new Business.CadastroClienteBusiness();
        Business.GerenciadorFotoBusiness gerenciadorFoto = new Business.GerenciadorFotoBusiness();
        Utils.CadastroClienteConversor cadastroConversor = new Utils.CadastroClienteConversor();
        Utils.GeralConversor geralConversor = new Utils.GeralConversor();

        [HttpPost]
        public ActionResult<Models.Response.LoginResponse> CadastrarCliente([FromForm] Models.Request.CadastroUsuario cadastroCliente)
        {
            try
            {
                business.VerSeSenhasSaoIguais(cadastroCliente.Senha1, cadastroCliente.Senha2);

                Models.TbLogin login = cadastroConversor.ParaTbLogin(cadastroCliente);
                Models.TbCliente cliente = cadastroConversor.ParaTbCliente(cadastroCliente);

                cliente.DsFoto = gerenciadorFoto.GerarNovoNome(cadastroCliente.ImagemUsuario.FileName);

                login = business.CadastrarCliente(login, cliente);

                gerenciadorFoto.SalvarFoto(cliente.DsFoto, cadastroCliente.ImagemUsuario);

                Models.Response.LoginResponse loginResponse = geralConversor.ParaLoginResponse(login);
               
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