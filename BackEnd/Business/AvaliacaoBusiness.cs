using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Business
{
    public class AvaliacaoBusiness
    {
        Validador.ValidadorSituacoes validarSituacoes = new Validador.ValidadorSituacoes();
        Database.AvaliacaoDatabase db = new Database.AvaliacaoDatabase();

        public void AvaliarTestDriver(int id, Models.Request.AvaliacaoRequest nota)
        {
            validarSituacoes.ValidarId(id);

            validarSituacoes.ValidarNota(nota.Nota);

            db.AvaliarTestDriver(id, nota);
        }
    }
}