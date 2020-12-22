using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Request
{
    public class NovoCarroRequest
    {
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public string Cor {get; set;}
        public int AnoFabricacao {get; set;}
        public int AnoVersao {get; set;}
        public int QtdCarros {get; set;}

    }
}