using System;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace BackEnd.Business
{
    public class GerenciadorFotoBusiness
    {
        public string GerarNovoNome(string nome)
        {
            string novoNome = Guid.NewGuid().ToString();
            novoNome = novoNome + Path.GetExtension(nome);
            return novoNome;
        }

        public void SalvarFoto (string nome, IFormFile foto)
        {
            string caminhoFoto =Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            using (FileStream fs = new FileStream(caminhoFoto, FileMode.Create))
            {
                foto.CopyTo(fs);
            }
        }

        public byte[] LerFoto(string nome)
        {
            string caminhoFoto = Path.Combine(AppContext.BaseDirectory, "Storage", "Fotos", nome);
            byte[] foto = File.ReadAllBytes(caminhoFoto);
            return foto;
        }

        public string GerarContentType(string nome)
        {
            string extensao = System.IO.Path.GetExtension(nome).Replace(".", "");
            string contentType = "application/" + extensao;
            return contentType;
        }

    }
}