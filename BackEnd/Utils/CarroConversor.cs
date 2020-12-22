using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Utils
{
    public class CarroConversor
    {
        public List<Models.TbCarro> ParaListTbCarro (Models.Request.NovoCarroRequest request)
        {
            List<Models.TbCarro> listaDeCarros  = new List<Models.TbCarro>();

            int qtdCarros = request.QtdCarros;

            for(int i = 1; i <= qtdCarros; i++)
            {
                Models.TbCarro carro = new Models.TbCarro();

                carro.BtDisponivel = true;
                carro.DsCor = request.Cor;
                carro.DsMarca = request.Marca;
                carro.DsModelo = request.Modelo;
                carro.NrAnoFabricacao = request.AnoFabricacao;
                carro.NrAnoVersao = request.AnoVersao;
                
                listaDeCarros.Add(carro);
            }

            return listaDeCarros;
        }        
    }
}