using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class CarroDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        public void AdicionarCarros (List<Models.TbCarro> listaDeCarros)
        {
            ctx.TbCarro.AddRange(listaDeCarros);
            ctx.SaveChanges();
        }        
    }
}