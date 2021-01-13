using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class ProcuraPorUsuarioController : ControllerBase
    {
        Business.ProcuraPorUsuarioBusiness business = new Business.ProcuraPorUsuarioBusiness();
        Utils.ProcuraPorUsuarioConversor conversor = new Utils.ProcuraPorUsuarioConversor();
        
        [HttpGet("cliente")]
        public ActionResult<List<Models.Response.InformacoesClienteResponse>> ProcurarCliente (string nome)
        {
            try
            {
                List<Models.TbCliente> clientes = business.ProcurarCliente(nome);

                List<Models.Response.InformacoesClienteResponse> response = conversor.ParaInfoCliente(clientes);

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        
        [HttpGet("funcionario")]
        public ActionResult<List<Models.Response.InformacoesFuncionarioResponse>> ProcuraFuncionario(string nome)
        {
            try
            {
                List<Models.TbFuncionario> funcionarios = business.ProcurarFuncionario(nome);

                List<Models.Response.InformacoesFuncionarioResponse> response = conversor.ParaInfoFuncionario(funcionarios);

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpDelete("{idUsuario}")]
        public ActionResult<Models.Response.SucessoResponse> DeletarUsuario (int idUsuario)
        {
            try
            {
                business.DeletarUsuario(idUsuario);
                return new Models.Response.SucessoResponse(200, "Usuário deletado.");
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