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

        public void AdicionarNovoCarro(List<Models.TbCarro> listaDeCarros)
        {
            db.AdicionarCarros(listaDeCarros);
        }   
    }
}