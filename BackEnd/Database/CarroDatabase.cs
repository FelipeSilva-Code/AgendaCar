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
        public void AdicionarCarros (Models.TbCarro carro)
        {
            ctx.TbCarro.Add(carro);
            ctx.SaveChanges();
        }

        public List<Models.TbCarro> ListarCarros(string busca)
        {
            List<Models.TbCarro> carros = ctx.TbCarro.ToList();
           
            if (string.IsNullOrEmpty(busca))
                return carros;

            List<Models.TbCarro> listaDeCarros = new List<Models.TbCarro>();

            busca = busca.ToLower();

            foreach(Models.TbCarro item in carros)
            {
                if(item.DsCor.ToLower().Contains(busca) || item.DsMarca.ToLower().Contains(busca) || item.DsModelo.ToLower().Contains(busca))
                    listaDeCarros.Add(item);
            }
            return listaDeCarros;
        }

        public void DeletarCarro(int? idCarro)
        {
            Models.TbCarro carro = ctx.TbCarro.FirstOrDefault(x => x.IdCarro == idCarro);
            ctx.TbCarro.Remove(carro);
            ctx.SaveChanges();
        }
    }
}