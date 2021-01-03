using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Response
{
    public class InformacoesClienteResponse
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CNH { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ImagemUsuario { get; set; }
    }
}