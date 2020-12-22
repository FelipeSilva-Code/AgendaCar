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
    public class AvaliacaoController : ControllerBase
    {
        Business.AvaliacaoBusiness business = new Business.AvaliacaoBusiness();

        [HttpPut("{id}")]
        public ActionResult<string> AvaliarTestDriver(int id, Models.Request.AvaliacaoRequest nota)
        {

            try
            {
                business.AvaliarTestDriver(id, nota);
                return "Alterado com sucesso";
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