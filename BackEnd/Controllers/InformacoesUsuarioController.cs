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
        Utils.InformacoesUsuarioConversor conversor = new Utils.InformacoesUsuarioConversor();

        [HttpGet("{idUsuario}")]
        public ActionResult<Models.Response.InformacoesResponse> PegarInformacoesUsuario (int idUsuario)
        {
    
            try
            {
                Models.TbCliente cliente = business.PegarInformacoesUsuario(idUsuario);

                Models.Response.InformacoesResponse informacoesResponse = conversor.ParaInformacoesResponse(cliente);

                return informacoesResponse;         
            }
            catch (System.Exception ex)
            {
                return BadRequest (new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }
    }
}