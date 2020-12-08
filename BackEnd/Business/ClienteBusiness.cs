using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Business
{
    public class ClienteBusiness
    {

        Database.ClienteDatabase database = new Database.ClienteDatabase();
        Business.ValidadorSituacoes ValidarSituacao = new ValidadorSituacoes();
        Business.ValidacoesAgendamentoBusiness ValidacoesAgendamentos = new ValidacoesAgendamentoBusiness();
         

        
        public List<Models.TbAgendamento> ListarAgendados(int id)
        {
            ValidarSituacao.ValidarId(id);

            return ValidacoesAgendamentos.VerSeTemAgendamentos(database.ListarAgendados(id));
        }

        public void AvaliarTestDriver(int id, Models.Request.AvaliacaoRequest nota)
        {
            ValidarSituacao.ValidarId(id);

            ValidarSituacao.ValidarNota(nota.Nota);
            
            database.AvaliarTestDriver(id, nota);
        }

        public void AgendarNovo (Models.TbAgendamento agendamento)
        {
            ValidacoesAgendamentos.ValidarAgendamento(agendamento);

            database.AgendarNovo(agendamento);
        }

        public List<Models.TbCarro> ListarCarrosDisponiveis ()
        {
            return database.ListarCarrosDisponiveis();
        }

        public List<Models.TbCarro> ListarCarrosPorMarca (string marca)
        {
            return database.ListarCarrosPorMarca(marca);
        }

        public Models.TbCarro PegarCarroPeloModelo(string modelo)
        {
            return database.PegarCarroPeloModelo(modelo);
        }

     
    

    }
}