using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Models.Response
{
    public class AgendadosResponse
    {
        public int idCliente {get; set;}
        public int idAgendamento {get; set;}
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public string Funcionario {get; set;}
        public DateTime? Data {get; set;}
        public string Situacao {get; set;} 
    }

    public class AgendadosResponseCompleto 
    {
        public List<AgendadosResponse> Hoje {get; set;}
        public List<AgendadosResponse> Amanha {get;set;}
        public List<AgendadosResponse> Depois {get; set;}
        public List<AgendadosResponse> Concluidos {get; set;}
        public List<AgendadosResponse> Outros {get; set;} 
    }
}