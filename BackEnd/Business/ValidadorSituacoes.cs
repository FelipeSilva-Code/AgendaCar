using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business
{
    public class ValidadorSituacoes
    {
        Database.ValidacoesDatabase db = new Database.ValidacoesDatabase();
        

        public void ValidarId (int? id)
        {
            if(id == 0 || id == null)
            throw new ArgumentException("Algo errado, tente novamente.");
        }

        public void ValidarNota (int nota)
        {
            if(nota < 1)
             throw new ArgumentException("A nota não pode ser menor que 1");

            if(nota > 5)
              throw new ArgumentException("A nota não pode ser maior que 5");
        }

      

       
    }
}