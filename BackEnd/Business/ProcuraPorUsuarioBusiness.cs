using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Business
{
    public class ProcuraPorUsuarioBusiness
    {
        Database.ProcuraPorUsuarioDatabase db = new Database.ProcuraPorUsuarioDatabase();

        
        public List<Models.TbCliente> ProcurarCliente (string nome)
        {
            if(nome == null)
                nome = "";

            nome = nome.ToLower();

            List<Models.TbCliente> clientes = db.ProcurarCliente(nome);

            if(clientes == null || clientes.Count == 0 )
                throw new ArgumentException("Nenhum usuário encontrado.");

            return clientes;        
        }

        public List<Models.TbFuncionario> ProcurarFuncionario(string nome)
        {
            if (nome == null)
                nome = "";

            nome = nome.ToLower();

            List<Models.TbFuncionario> funcionarios = db.ProcurarFuncionario(nome);

            if (funcionarios == null || funcionarios.Count == 0)
                throw new ArgumentException("Nenhum usuário encontrado.");

            return funcionarios;
        }
        public void DeletarUsuario(int? idUsuario)
        {
            if(idUsuario == null || idUsuario == 0)
                throw new ArgumentException("Ocorreu um erro, tente novamente.");

            db.DeletarUsuario(idUsuario);
        }

        

    }
}