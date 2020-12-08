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
    public class FuncionarioController : ControllerBase
    {

        Business.FuncionarioBusiness business = new Business.FuncionarioBusiness();
        Utils.GeralConversor conversor = new Utils.GeralConversor();
        
        
        [HttpGet("agendados/{idFuncionario}")]
        public ActionResult<Models.Response.AgendadosResponseCompleto> RetornarAgendadosFuncionario (int idFuncionario)
        {
          try
          {
            List<Models.TbAgendamento> agendamentos = business.RetornarAgendadosFuncionario(idFuncionario);
            if(agendamentos.Count == 0)
            return NotFound("Nenhum agendamento encontrado!!!");

            Models.Response.AgendadosResponseCompleto response = new Models.Response.AgendadosResponseCompleto();

            response = conversor.SepararPorTipo(agendamentos);

            return response;
 
          }
          catch (System.Exception ex)
          {
              
              return BadRequest( new Models.Response.ErroResponse(
                  400, ex.Message
              ));
          }
        }



        [HttpPut("MudarSituacao/{idAgendamento}")]
        public ActionResult<string> MudarSituacao (int idAgendamento ,Models.Request.MudarSituacao situacao)
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

        [HttpPut("Aceitar/{idFuncionario}/{idAgendamento}")]
        public ActionResult<Models.Response.AgendadosResponse> AceitarAgendamento (int idFuncionario, int idAgendamento)
        {
          try
          {
               Models.TbAgendamento agendamento = business.AceitarAgendamento(idFuncionario, idAgendamento);

               Models.Response.AgendadosResponse response = conversor.ParaResponseAgendados(agendamento);

               return response;
          }
          catch (System.Exception ex)
          { 
              return BadRequest(new Models.Response.ErroResponse(
                400, ex.Message
              ));
          }
          
        }

        [HttpGet("EsperandoAceitacao")]
        public ActionResult<List<Models.Response.AgendadosResponse>> VerEsperandoAceitacao ()
        {
          try
          {
              List<Models.TbAgendamento> agendados = business.VerEsperandoAceitacao();

              return conversor.SomenteEsperandoAceitacao(agendados).OrderBy( x => x.Data).ToList();
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