using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class InformacoesUsuarioDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        public Models.TbCliente PegarInformacoesUsuario(int? idUsuario)
        {
            Models.TbCliente cliente = ctx.TbCliente.Include(x => x.IdLoginNavigation)
                                                    .FirstOrDefault(x => x.IdCliente == idUsuario);

            return cliente;
        }
    }
}