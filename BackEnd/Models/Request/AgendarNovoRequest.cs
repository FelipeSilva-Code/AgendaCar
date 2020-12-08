using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Request
{
    public class AgendarNovoRequest
    {
        public int IdCliente {get; set;}
        public int IdCarro {get; set;}
        public DateTime Data {get; set;}
    }
}