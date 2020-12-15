using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Response
{
    public class LoginResponse
    {
        public int IdUsuario {get; set;}
        public string Perfil {get; set;}
        public string Foto {get; set;}
    }
}