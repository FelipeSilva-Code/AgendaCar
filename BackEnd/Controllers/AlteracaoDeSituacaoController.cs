using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]

   
    public class AlteracaoDeSituacaoController : ControllerBase
    {
        Business.AlteracaoDeSituacaoBusiness business = new Business.AlteracaoDeSituacaoBusiness();
        Utils.AlteracaoDeSituacaoConversor conversor = new Utils.AlteracaoDeSituacaoConversor();


        [HttpGet("EsperandoAceitacao")]
        public ActionResult<List<Models.Response.AgendadosResponse>> VerEsperandoAceitacao()
        {
            try
            {
                List<Models.TbAgendamento> agendados = business.VerEsperandoAceitacao();

                return conversor.SomenteEsperandoAceitacao(agendados).OrderBy(x => x.Data).ToList();
            }
            catch (System.Exception ex)
            {

                return BadRequest(new Models.Response.ErroResponse(
                  400, ex.Message
                ));
            }
        }

        [HttpPut("MudarSituacao/{idAgendamento}")]
        public ActionResult<string> MudarSituacao(int idAgendamento, Models.Request.MudarSituacao situacao)
        {
            try
            {
                business.MudarSituacao(idAgendamento, situacao);
                return ("Situação alterada com sucesso!");

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