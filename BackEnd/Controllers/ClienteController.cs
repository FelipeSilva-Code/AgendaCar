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
    public class ClienteController : ControllerBase
    {
        Business.ClienteBusiness business = new Business.ClienteBusiness();
        Utils.GeralConversor conversor = new Utils.GeralConversor();


       
        [HttpGet("agendados/{id}")]
        public ActionResult<Models.Response.AgendadosResponseCompleto> ListarAgendados(int id)
        {

            try
            {
            
                List<Models.TbAgendamento> agendamentos = business.ListarAgendados(id);
                if (agendamentos.Count == 0 || agendamentos == null)
                    return NotFound("Nenhum agendamento encontrado");
                

                Models.Response.AgendadosResponseCompleto listaAgendados = conversor.SepararPorTipo(agendamentos);

                return listaAgendados;   
            }
            catch (System.Exception ex)
            {  
               return BadRequest (new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
          
        }

        [HttpPut("agendados/avaliar/{id}")]
        public ActionResult<string> AvaliarTestDriver(int id, Models.Request.AvaliacaoRequest nota)
        {  

            try
            {
                business.AvaliarTestDriver(id, nota);
                return "Alterado com sucesso";
            }
            catch (System.Exception ex)
            {
                return BadRequest (new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
             
        }

        [HttpPost("agendar")]
        public ActionResult<string> AgendarTestDrive (Models.Request.AgendarNovoRequest request)
        {
            try
            {
                Models.TbAgendamento agendamento = conversor.ParaAgendamentoTabela(request);
                business.AgendarNovo(agendamento);
                return "Agendado com sucesso!!!";
            }
            catch (System.Exception ex)
            {
                
                return BadRequest( new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        
        [HttpGet("listar/carro")]
        public ActionResult<List<Models.Response.CarrosDisponiveis>> ListarCarrosDisponiveis ()
        {
            try
            {
                List<Models.TbCarro> listaDeCarros = business.ListarCarrosDisponiveis();
                if(listaDeCarros.Count == 0 || listaDeCarros == null)
                   return NotFound("Nenhum carro disponivel");

                 return conversor.ListarParaResponseCarro(listaDeCarros, "Marca");

            }
            catch (System.Exception ex)
            {
                
                return BadRequest( new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("{marca}/listar")]
        public ActionResult<List<Models.Response.CarrosDisponiveis>> ListarCarrosPorMarca (string marca)
        {
            try
            {
                return conversor.ListarParaResponseCarro(business.ListarCarrosPorMarca(marca), "Modelo");
            }
            catch (System.Exception ex)
            {
                
                return BadRequest (new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet("{modelo}/carroUnico")]
        public ActionResult<Models.Response.CarrosDisponiveis> PegarCarroPeloModelo (string modelo)
        {
            try
            {
                return conversor.ParaResponseCarro(business.PegarCarroPeloModelo(modelo));
            }
            catch (System.Exception ex)
            {
                return BadRequest( new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }
        
     
    }
}