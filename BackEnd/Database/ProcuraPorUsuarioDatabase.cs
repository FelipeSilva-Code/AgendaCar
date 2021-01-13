using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Database
{
    public class ProcuraPorUsuarioDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        public List<Models.TbCliente> ProcurarCliente(string nome)
        {
            List<Models.TbCliente> clientes = ctx.TbCliente.Include(x => x.IdLoginNavigation)
                                                          .Where(x => x.NmCliente.ToLower().Contains(nome)).ToList();

            return clientes;                                              
        }   

        public List<Models.TbFuncionario> ProcurarFuncionario (string nome)
        {
            List<Models.TbFuncionario> funcionarios = ctx.TbFuncionario.Include(x => x.IdLoginNavigation)
                                                    .Where(x => x.NmFuncionario.ToLower().Contains(nome)).ToList();

            return funcionarios;                                        
        }

        public void DeletarUsuario(int? idUsuario)
        {

            Models.TbLogin TbLogin = ctx.TbLogin.FirstOrDefault(x => x.IdLogin == idUsuario);
            ctx.Remove(TbLogin);
            ctx.SaveChanges();
            

        }
    }
}