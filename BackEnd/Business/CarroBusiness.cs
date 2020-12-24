using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class CarroBusiness
    {
        Business.Validador.ValidadorCarro validadorCarro = new Business.Validador.ValidadorCarro();
        Database.CarroDatabase db = new Database.CarroDatabase();
        public void ValidarInformacoesDoCarroQueSeraAdicionado(Models.Request.NovoCarroRequest carroRequest)
        {
            validadorCarro.GerenciarNovoCarro(carroRequest);
        }

        public void AdicionarNovoCarro(Models.TbCarro carro)
        {
            db.AdicionarCarros(carro);
        }

        public List<Models.TbCarro> ListarCarros(string busca)
        {
            return db.ListarCarros(busca);
        }

        public void DeletarCarro(int? idCarro)
        {
            if (idCarro == 0 || idCarro == null)
                throw new ArgumentException("Houve um erro, tente novamente mais tarde.");

            db.DeletarCarro(idCarro);
        }

        public Models.TbCarro PegarInfoDoCarro(int? idCarro)
        {
            if(idCarro == 0 || idCarro == null)
                throw new ArgumentException("Houve um erro, tente novamente mais tarde.");

            return db.PegarInfoDoCarro(idCarro);   
        }
    }
}