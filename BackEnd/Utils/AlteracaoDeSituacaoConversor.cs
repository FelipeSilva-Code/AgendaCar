using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class AlteracaoDeSituacaoConversor
    {
        VerAgendamentosConversor agendamentosConversor = new VerAgendamentosConversor();
        public List<Models.Response.AgendadosResponse> SomenteEsperandoAceitacao(List<Models.TbAgendamento> agendamentos)
        {
            List<Models.Response.AgendadosResponse> respose = agendamentosConversor.ListaResponseAgendados(agendamentos);

            return respose.Where(x => x.Situacao == "Pendente" && x.Data > DateTime.Now).ToList();
        }
    }
}