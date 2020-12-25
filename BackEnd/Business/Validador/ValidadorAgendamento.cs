using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business.Validador
{
    public class ValidacoesAgendamento
    {


        Database.ValidacoesDatabase dbValidacoes = new Database.ValidacoesDatabase();

       
       //Exibir Agendamentos

       public List<Models.TbAgendamento> VerSeTemAgendamentos (List<Models.TbAgendamento> agendamento)
       {
               if(agendamento == null || agendamento.Count == 0 )
                  throw new ArgumentException("Você não tem agendamentos.");
               else
                  return agendamento;   
       }

       
       
       //Agendar
        public void ValidarAgendamento (Models.TbAgendamento agendamento)
        {
             this.ValidarDataDoAgendamento(agendamento.DtAgendamento, agendamento.IdCliente);
             
             this.ValidarCarroDoAgendamento(agendamento.IdCarro);
        }

        public void ValidarDataDoAgendamento (DateTime? dataAgendamento, int? idCliente)
        {
            if (dataAgendamento < DateTime.Now)
                throw new ArgumentException("A data do agendamento, não pode ser menor do que a data atual");
            
            else if (dataAgendamento.Value.DayOfWeek == DayOfWeek.Saturday || dataAgendamento.Value.DayOfWeek == DayOfWeek.Sunday)
                throw new ArgumentException("O test drive não pode ser em um final de semana");

            else if (dataAgendamento > DateTime.Now.AddDays(14))
                throw new ArgumentException("A data do agendamento não pode ser maior do que 2 semanas");   

            else if (dataAgendamento.Value.Hour >= 17 || dataAgendamento.Value.Hour < 8)
                 throw new ArgumentException("Estamos fechados nesse horário"); 

            else if (dataAgendamento.Value.Hour >= 12 && dataAgendamento.Value.Hour < 13) 
                throw new ArgumentException("Horário de almoço dos funcionários");

            else if (dbValidacoes.ValidarDataAgendamento(dataAgendamento, idCliente))
                throw new ArgumentException("Você ja tem um test drive marcado nesse horário");     
        }

        public void ValidarCarroDoAgendamento (int? idDoCarro)
        {
            if(idDoCarro == 0)
                throw new ArgumentException("A escolha de um carro é obrigatória");
                
            if (dbValidacoes.ValidarCarroDoAgendamento(idDoCarro))
               throw new ArgumentException ("Esse carro está indiponivel");
        }

      
        
    }
}