using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Request
{
    public class AlterarSenhaRequest
    {
        public string SenhaAtual {get; set;}
        public string NovaSenha1 {get; set;}
        public string NovaSenha2 {get; set;}
    }
}