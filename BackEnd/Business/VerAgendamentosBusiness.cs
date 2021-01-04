using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class VerAgendamentosBusiness
    {
        Validador.ValidadorSituacoes validarSituacoes = new Validador.ValidadorSituacoes();
        Validador.ValidacoesAgendamento validacoesAgendamentos = new Validador.ValidacoesAgendamento();
        Database.VerAgendamentosDatabase db = new Database.VerAgendamentosDatabase();
        public List<Models.TbAgendamento> ListarAgendadosCliente(int id)
        {
            validarSituacoes.ValidarId(id);

            return validacoesAgendamentos.VerSeTemAgendamentos(db.ListarAgendadosCliente(id));
        }

        public List<Models.TbAgendamento> RetornarAgendadosFuncionario(int idFuncionario)
        {
            validarSituacoes.ValidarId(idFuncionario);
            return db.RetornarAgendadosFuncionario(idFuncionario);
        }

        public List<Models.TbAgendamento> PegarTodosAgendamentos()
        {
            return db.PegarTodosAgendamentos();
        }
    }
}