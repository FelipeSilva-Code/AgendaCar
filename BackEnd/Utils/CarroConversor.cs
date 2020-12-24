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
        public Models.TbCarro ParaListTbCarro (Models.Request.NovoCarroRequest request)
        {

            Models.TbCarro carro = new Models.TbCarro();

            carro.BtDisponivel = true;
            carro.DsCor = request.Cor;
            carro.DsMarca = request.Marca;
            carro.DsModelo = request.Modelo;
            carro.NrAnoFabricacao = request.AnoFabricacao;
            carro.NrAnoVersao = request.AnoVersao;
            carro.QtdDisponivel = request.QtdCarros;
            carro.QtdTotal = request.QtdCarros;

            return carro;
        }    

        public List<Models.Response.CarrosResponse> ListarCarros (List<Models.TbCarro> carros)
        {
            List<Models.Response.CarrosResponse> carrosResponse = new List<Models.Response.CarrosResponse>();

            foreach(Models.TbCarro item in carros)
            {
                Models.Response.CarrosResponse carrosForeach = new Models.Response.CarrosResponse();

                carrosForeach.AnoFabricacao = item.NrAnoFabricacao;
                carrosForeach.AnoModelo = item.NrAnoVersao;
                carrosForeach.Cor = item.DsCor;
                carrosForeach.Marca = item.DsMarca;
                carrosForeach.Id = item.IdCarro;
                carrosForeach.Modelo = item.DsModelo;
                carrosForeach.QtdDisponivel = item.QtdDisponivel;
                carrosForeach.QtdTotal = item.QtdTotal;
                
                carrosResponse.Add(carrosForeach);
                
            }

            return carrosResponse.OrderBy(x => x.Marca).ToList();
        }  

        public Models.Response.CarrosResponse SomenteUmCarroResponse (Models.TbCarro carro)   
        {
            Models.Response.CarrosResponse carrosResponse = new Models.Response.CarrosResponse();

            carrosResponse.AnoFabricacao = carro.NrAnoFabricacao;
            carrosResponse.AnoModelo = carro.NrAnoVersao;
            carrosResponse.Cor = carro.DsCor;
            carrosResponse.Id = carro.IdCarro;
            carrosResponse.Marca = carro.DsMarca;
            carrosResponse.Modelo = carro.DsModelo;
            carrosResponse.QtdDisponivel = carro.QtdDisponivel;
            carrosResponse.QtdTotal = carro.QtdTotal;
            
            return carrosResponse;
        }
    
    
    }
}