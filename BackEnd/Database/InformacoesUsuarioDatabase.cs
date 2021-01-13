using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Database
{
    public class InformacoesUsuarioDatabase
    {
        Models.db_test_driveContext ctx = new Models.db_test_driveContext();
        public Models.TbCliente PegarInformacoesCliente(int? idCliente)
        {
            Models.TbCliente cliente = ctx.TbCliente.Include(x => x.IdLoginNavigation)
                                                    .FirstOrDefault(x => x.IdCliente == idCliente);

            return cliente;
        }

        public void AlterarInformacoesCliente (Models.TbLogin login, Models.TbCliente cliente)
        {
            Models.TbCliente clienteQueSeraAlterado = this.PegarInformacoesCliente(cliente.IdCliente);
            clienteQueSeraAlterado.DsCnh = cliente.DsCnh;
            clienteQueSeraAlterado.DsCpf = cliente.DsCpf;
            clienteQueSeraAlterado.DsTelefone = cliente.DsTelefone;
            clienteQueSeraAlterado.DtNascimento = cliente.DtNascimento;
            clienteQueSeraAlterado.NmCliente = cliente.NmCliente;
            clienteQueSeraAlterado.IdLoginNavigation.DsEmail = login.DsEmail;

            if (cliente.DsFoto != null)
                clienteQueSeraAlterado.DsFoto = cliente.DsFoto;

            ctx.SaveChanges();
        }

        public bool VerSeASenhaAtualEstaCertaCliente(string senhaPassada, int idUsuario)
        {
            Models.TbCliente cliente = this.PegarInformacoesCliente(idUsuario);
            string senhaAtualDoBanco = cliente.IdLoginNavigation.DsSenha;
            bool mesmaSenha = senhaAtualDoBanco == senhaPassada;
            return mesmaSenha;
        }

        public void AlterarSenhaCliente (string novaSenha, int idUsuario)
        {
            Models.TbCliente cliente = this.PegarInformacoesCliente(idUsuario);

            cliente.IdLoginNavigation.DsSenha = novaSenha;
            ctx.SaveChanges();
        }


        // Funcionário
        public Models.TbFuncionario PegarInformacoesFuncionario(int? idFuncionario)
        {
            Models.TbFuncionario funcionario = ctx.TbFuncionario.Include(x => x.IdLoginNavigation)
                                                    .FirstOrDefault(x => x.IdFuncionario == idFuncionario);

            return funcionario;
        }


    }
}