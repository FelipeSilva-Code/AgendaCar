using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Business.Validador
{
    public class ValidadorCadastro
    {
        Validador.ValidadorSituacoes validadorSituacoes = new ValidadorSituacoes();
        public void GerenciarValidacoesCadastroCliente (Models.TbLogin login, Models.TbCliente cliente)
        {
            login = validadorSituacoes.TirarEspacosDosCamposLogin(login);
            cliente = validadorSituacoes.TirarEspacosDosCamposCliente(cliente);
            this.ValidarCnh(cliente.DsCnh);
            this.ValidarForcaDaSenha(login.DsSenha);
            this.ValidarNascimento(cliente.DtNascimento);
            this.ValidarCpf(cliente.DsCpf);
            validadorSituacoes.ValidarEmail(login.DsEmail);
    
        }

        public void ValidarCpf (string cpf)
        {
            if(string.IsNullOrEmpty(cpf))
                throw new ArgumentException("O CPF é obrigatório");
            
            else if(cpf.Length != 14)
                throw new ArgumentException("O CPF está incorreto.");
        }

        public void ValidarCnh (string cnh)
        {
            if (string.IsNullOrEmpty(cnh))
                throw new ArgumentException("A CNH é obrigatória");

            else if (cnh.Length != 11)
                throw new ArgumentException("A CNH está incorreta");    
        }

        public void ValidarNascimento (DateTime? dataNascimento)
        {
            DateTime hoje = DateTime.Now;
            DateTime anoParaSerDeMaior = hoje.AddYears(-18);
            int nascimento = dataNascimento.Value.Year;
           
            if(dataNascimento > DateTime.Now)
                throw new ArgumentException("A data de nascimento não pode ser maior do que a data atual.");
           
            else if(nascimento > anoParaSerDeMaior.Year || anoParaSerDeMaior.Year == nascimento && anoParaSerDeMaior.DayOfYear < dataNascimento.Value.DayOfYear)    
                throw new ArgumentException("Cadastro permitido apenas para maiores de idade.");  
        }

        public void ValidarForcaDaSenha(string senha)
        {

            if (senha.Length < 8)
                throw new ArgumentException("A senha deve conter no mínimo 8 caracteres.");

            if (this.QuantidadeDeNumeros(senha))
                throw new ArgumentException("A senha deve conter no mínimo dois números.");

            if (this.CaracteresEspeciais(senha))
                throw new ArgumentException("A senha deve conter no mínimo um caractere especial.");

        }

        public bool QuantidadeDeNumeros(string senha)
        {
            int x = 0;
            for (int i = 0; i < senha.Length; i++)
            {
                if (senha[i] == '0' || senha[i] == '1' || senha[i] == '1' || senha[i] == '3' || senha[i] == '4'
                 || senha[i] == '5' || senha[i] == '6' || senha[i] == '7' || senha[i] == '8' || senha[i] == '9')
                    x++;
            }

            return x < 2;
        }

        public bool CaracteresEspeciais(string senha)
        {
            int x = 0;
            for (int i = 0; i < senha.Length; i++)
            {
                if (senha[i] == '!' || senha[i] == '@' || senha[i] == '#' || senha[i] == '$' || senha[i] == '%' || senha[i] == 5 ||
                    senha[i] == '&' || senha[i] == '*')
                    x++;

            }

            return x < 1;
        }



        
    }
}