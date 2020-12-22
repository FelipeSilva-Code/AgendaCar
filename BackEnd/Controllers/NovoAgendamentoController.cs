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
    public class NovoAgendamentoController :ControllerBase
    {
        Business.NovoAgendamentoBusiness business = new Business.NovoAgendamentoBusiness();
        Utils.NovoAgendamentoConversor conversor = new Utils.NovoAgendamentoConversor();
        Utils.VerAgendamentosConversor verAgendamentosConversor = new Utils.VerAgendamentosConversor();
        
        
        [HttpGet("listar/carro")]
        public ActionResult<List<Models.Response.CarrosDisponiveis>> ListarCarrosDisponiveis()
        {
            try
            {
                List<Models.TbCarro> listaDeCarros = business.ListarCarrosDisponiveis();
                if (listaDeCarros.Count == 0 || listaDeCarros == null)
                    return NotFound("Nenhum carro disponivel");

                return conversor.ListarParaResponseCarro(listaDeCarros, "Marca");

            }
            catch (System.Exception ex)
            {

                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("{marca}/listar")]
        public ActionResult<List<Models.Response.CarrosDisponiveis>> ListarCarrosPorMarca(string marca)
        {
            try
            {
                return conversor.ListarParaResponseCarro(business.ListarCarrosPorMarca(marca), "Modelo");
            }
            catch (System.Exception ex)
            {

                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("{modelo}/carroUnico")]
        public ActionResult<Models.Response.CarrosDisponiveis> PegarCarroPeloModelo(string modelo)
        {
            try
            {
                return conversor.ParaResponseCarro(business.PegarCarroPeloModelo(modelo));
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }


        [HttpPost("agendar")]
        public ActionResult<string> AgendarTestDrive(Models.Request.AgendarNovoRequest request)
        {
            try
            {
                Models.TbAgendamento agendamento = conversor.ParaAgendamentoTabela(request);
                business.AgendarNovo(agendamento);
                return "Agendado com sucesso!!!";
            }
            catch (System.Exception ex)
            {

                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        //Funcionário
        [HttpPut("Aceitar/{idFuncionario}/{idAgendamento}")]
        public ActionResult<Models.Response.AgendadosResponse> AceitarAgendamento(int idFuncionario, int idAgendamento)
        {
            try
            {
                Models.TbAgendamento agendamento = business.AceitarAgendamento(idFuncionario, idAgendamento);

                Models.Response.AgendadosResponse response = verAgendamentosConversor.ParaResponseAgendados(agendamento);

                return response;
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