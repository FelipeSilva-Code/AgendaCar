using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Response
{
    public class InformacoesContaUsuarioResponse
    {
        public int? IdLogin {get; set;}
        public int IdUsuario {get; set;}
        public string Perfil {get; set;}
        public string Email {get; set;}
        public string NomeUsuario {get; set;}
        public string NomeImagem {get; set;}
    }
}