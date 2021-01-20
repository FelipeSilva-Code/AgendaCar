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
    public class NovoAgendamentoController :ControllerBase
    {
        Business.NovoAgendamentoBusiness business = new Business.NovoAgendamentoBusiness();
        Utils.NovoAgendamentoConversor conversor = new Utils.NovoAgendamentoConversor();
        Utils.VerAgendamentosConversor verAgendamentosConversor = new Utils.VerAgendamentosConversor();
        private readonly ILogger<NovoAgendamentoController> _logger;
        private readonly IMailer _mailer;

        public NovoAgendamentoController(ILogger<NovoAgendamentoController> logger, IMailer mailer)
        {
            _logger = logger;
            _mailer = mailer;
        }
        
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
        public async Task<ActionResult<Models.Response.SucessoResponse>> AgendarTestDrive(Models.Request.AgendarNovoRequest request)
        {
            try
            {
                Models.TbAgendamento agendamento = conversor.ParaAgendamentoTabela(request);
              
                string email = business.AgendarNovo(agendamento);
              
                string corpo = $"Olá, {agendamento.IdClienteNavigation.NmCliente}. O seu test drive para o dia {agendamento.DtAgendamento}, com o carro {agendamento.IdCarroNavigation.DsMarca} {agendamento.IdCarroNavigation.DsModelo} - {agendamento.IdCarroNavigation.DsCor} foi agendado. Agora basta esperar que um funcionário aceite.";

                await _mailer.EnviarEmailAsync(email, "Novo Agendamento", corpo);
              
                return new Models.Response.SucessoResponse(200, "Agendado com sucesso.");
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
        public async Task<ActionResult<Models.Response.AgendadosResponse>> AceitarAgendamento(int idFuncionario, int idAgendamento)
        {
            try
            {
                Models.TbAgendamento agendamento = business.AceitarAgendamento(idFuncionario, idAgendamento);

                Models.Response.AgendadosResponse response = verAgendamentosConversor.ParaResponseAgendados(agendamento);

                string corpo = $"Olá. Um funcionário aceitou o seu agendamento para {response.Data.Value.Day}/{response.Data.Value.Month} ás {response.Data.Value.Hour}:{response.Data.Value.Minute}. Você pode ver mais detalhadamente em nosso site. Estamos te esperando.";
               
                string email = business.PegarEmailUsuario(agendamento.IdCliente);
                
                await _mailer.EnviarEmailAsync(email, "Test Drive Confirmado", corpo);
                
                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                  400, ex.Message
                ));
            }

        }

        // Ambos
        [HttpPut("remarcar/{idAgendamento}")]
        public ActionResult<Models.Response.AgendadosResponse> RemarcarTestDrive (DateTime novoHorario, int idAgendamento)
        {
            try
            {
                Models.TbAgendamento agendamento = business.PegarAgendamentos(idAgendamento);
                agendamento = business.Remarcar(novoHorario, agendamento);
                
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