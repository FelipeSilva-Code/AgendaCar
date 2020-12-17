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
        public Models.TbCliente PegarInformacoesUsuario(int? idUsuario)
        {
            Models.TbCliente cliente = ctx.TbCliente.Include(x => x.IdLoginNavigation)
                                                    .FirstOrDefault(x => x.IdCliente == idUsuario);

            return cliente;
        }

        public void AlterarInformacoes (Models.TbLogin login, Models.TbCliente cliente)
        {
            Models.TbCliente clienteQueSeraAlterado = this.PegarInformacoesUsuario(cliente.IdCliente);
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

        public bool VerSeASenhaAtualEstaCerta(string senhaPassada, int idUsuario)
        {
            Models.TbCliente cliente = this.PegarInformacoesUsuario(idUsuario);
            string senhaAtualDoBanco = cliente.IdLoginNavigation.DsSenha;
            bool mesmaSenha = senhaAtualDoBanco == senhaPassada;
            return mesmaSenha;
        }

        public void AlterarSenha (string novaSenha, int idUsuario)
        {
            Models.TbCliente cliente = this.PegarInformacoesUsuario(idUsuario);

            cliente.IdLoginNavigation.DsSenha = novaSenha;
            ctx.SaveChanges();
        }


    }
}