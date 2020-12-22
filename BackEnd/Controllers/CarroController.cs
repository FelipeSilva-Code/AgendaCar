using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        Business.CarroBusiness business = new Business.CarroBusiness();
        Utils.CarroConversor conversor = new Utils.CarroConversor();

        [HttpPost]
        public ActionResult<Models.Response.SucessoResponse> AdicionarCarros (Models.Request.NovoCarroRequest carroRequest)
        {
            try
            {
                business.ValidarInformacoesDoCarroQueSeraAdicionado(carroRequest);

                List<Models.TbCarro> listaDeCarros = conversor.ParaListTbCarro(carroRequest);
                
                business.AdicionarNovoCarro(listaDeCarros);
                
                return new Models.Response.SucessoResponse(400, "Carro adicionado.");
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