using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business.Validador
{
    public class ValidadorCarro
    {
        public void GerenciarNovoCarro (Models.Request.NovoCarroRequest request)
        {
            request = this.TirarEspacosDosCamposNovoCarro(request);
            this.ValidarSeCampoENuloOuVazio(request.Marca, "A marca");
            this.ValidarSeCampoENuloOuVazio(request.Modelo, "O modelo");
            this.ValidarSeCampoENuloOuVazio(request.Cor, "A cor");
            this.ValidarAnoVersaoEFabricacao(request.AnoFabricacao, "de fabricação");
            this.ValidarAnoVersaoEFabricacao(request.AnoVersao, "da versão");
            this.ValidarQtdCarros(request.QtdCarros);
        }

        public void ValidarSeCampoENuloOuVazio (string valorPassado, string campo )
        {
            if(string.IsNullOrEmpty(valorPassado))
                throw new ArgumentException($"{campo} é obrigatório.");
        }

        public void ValidarAnoVersaoEFabricacao (int ano, string campo)
        {
            if(ano < 1950)
                throw new ArgumentException($"O ano {campo} não pode ser menor do 1950.");

            else if(ano > 2025)
                throw new ArgumentException($"{campo} não pode ser maior do que 2025.");
        }

        public void ValidarQtdCarros (int qtdCarros)
        {
            if(qtdCarros <= 0)
                throw new ArgumentException("A quantidade de carros deve ser de no minímo 1.");

        }

        public Models.Request.NovoCarroRequest TirarEspacosDosCamposNovoCarro(Models.Request.NovoCarroRequest novoCarro)
        {
            novoCarro.Marca = novoCarro.Marca.Trim();
            novoCarro.Modelo = novoCarro.Modelo.Trim();
            novoCarro.Cor = novoCarro.Cor.Trim();

            return novoCarro;
        }
    }
}