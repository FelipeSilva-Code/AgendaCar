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
    public class VerAgendamentosController : ControllerBase
    {

        Business.VerAgendamentosBusiness business = new Business.VerAgendamentosBusiness();
        Utils.VerAgendamentosConversor conversor = new Utils.VerAgendamentosConversor();

        [HttpGet("agendados/cliente/{idCliente}")]
        public ActionResult<Models.Response.AgendadosResponseCompleto> ListarAgendados(int idCliente)
        {

            try
            {

                List<Models.TbAgendamento> agendamentos = business.ListarAgendadosCliente(idCliente);
                if (agendamentos.Count == 0 || agendamentos == null)
                    return NotFound("Nenhum agendamento encontrado");


                Models.Response.AgendadosResponseCompleto listaAgendados = conversor.SepararPorTipo(agendamentos);

                return listaAgendados;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                     400, ex.Message
                 ));
            }

        }

        [HttpGet("agendados/funcionario/{idFuncionario}")]
        public ActionResult<Models.Response.AgendadosResponseCompleto> RetornarAgendadosFuncionario(int idFuncionario)
        {
            try
            {
                List<Models.TbAgendamento> agendamentos = business.RetornarAgendadosFuncionario(idFuncionario);
                if (agendamentos.Count == 0)
                    return NotFound("Nenhum agendamento encontrado!!!");

                Models.Response.AgendadosResponseCompleto response = new Models.Response.AgendadosResponseCompleto();

                response = conversor.SepararPorTipo(agendamentos);

                return response;

            }
            catch (System.Exception ex)
            {

                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("pegarTodosAgendamentos")]
        public ActionResult<Models.Response.AgendadosResponseCompleto> PegarTodosAgendamentos ()
        {
            try
            {
                List<Models.TbAgendamento> agendamentos = business.PegarTodosAgendamentos();

                if(agendamentos.Count == 0)
                    return NotFound("Nenhum agendamento encontrado");

                Models.Response.AgendadosResponseCompleto response = conversor.SepararPorTipo(agendamentos);    

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(400, ex.Message));
            }
        }
    }
}