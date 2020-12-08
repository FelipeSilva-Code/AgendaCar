using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Request
{
    public class AvaliacaoRequest
    {
        public int Nota {get; set;}
    }
}