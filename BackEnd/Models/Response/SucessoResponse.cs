using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Response
{
    public class SucessoResponse
    {
        public int Codigo {get; set;}
        public string Mensagem {get; set;}

        public SucessoResponse(int cdg, string msg)
        {
            this.Codigo = cdg;
            this.Mensagem = msg;

        }
    }
}