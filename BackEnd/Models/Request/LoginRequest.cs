using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Request
{
    public class LoginRequest
    {
        public string CPF { get; set; }
        public string Senha { get; set; }

    }
}