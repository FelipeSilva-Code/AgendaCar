using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.Models.Response
{
    public class CarrosDisponiveis
    {
        public int? Id {get; set;}
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public int? AnoFabricacao {get; set;}
        public int? AnoModelo {get; set;}
        public string Cor {get; set;}

    }
}