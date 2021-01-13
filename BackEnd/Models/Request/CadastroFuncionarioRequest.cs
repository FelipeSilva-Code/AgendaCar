using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BackEnd.Models.Request
{
    public class CadastroFuncionarioRequest
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CarteiraTrabalho { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha1 { get; set; }
        public string Senha2 { get; set; }
        public IFormFile ImagemUsuario { get; set; }
    }
}