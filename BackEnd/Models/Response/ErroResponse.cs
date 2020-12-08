using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Response
{
    public class ErroResponse
    {
        public string Mensagem {get; set;}
        public int    Codigo    {get; set;}

        public ErroResponse(int cdg, string msg)
        {
            this.Mensagem = msg;
            this.Codigo = cdg;
        }
    }
}