using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class NovoAgendamentoBusiness
    {
        Database.NovoAgendamentoDatabase db = new Database.NovoAgendamentoDatabase();
        Validador.ValidacoesAgendamento validadorAgendamentos = new Validador.ValidacoesAgendamento();
        Validador.ValidadorSituacoes validadorSituacoes = new Validador.ValidadorSituacoes();
        public List<Models.TbCarro> ListarCarrosDisponiveis()
        {
            return db.ListarCarrosDisponiveis();
        }

        public List<Models.TbCarro> ListarCarrosPorMarca(string marca)
        {
            return db.ListarCarrosPorMarca(marca);
        }

        public Models.TbCarro PegarCarroPeloModelo(string modelo)
        {
            return db.PegarCarroPeloModelo(modelo);
        }
        public string AgendarNovo(Models.TbAgendamento agendamento)
        {
            validadorAgendamentos.ValidarAgendamento(agendamento);

            string email = db.AgendarNovo(agendamento);

            this.MarcarCarroComoIndisponivel(agendamento.IdCarro);

            return email;
        }

        public void MarcarCarroComoIndisponivel(int? idCarro)
        {
            db.MarcarCarroComoIndisponivel(idCarro);
        }

        //Funcionário
        public Models.TbAgendamento AceitarAgendamento(int idFuncionario, int idAgendamento)
        {
            validadorSituacoes.ValidarId(idFuncionario);
            validadorSituacoes.ValidarId(idAgendamento);
            return db.AceitarAgendamento(idFuncionario, idAgendamento);
        }

        public string PegarEmailUsuario (int? idCliente)
        {
            return db.PegarEmailUsuario(idCliente);
        }

        
    }
}