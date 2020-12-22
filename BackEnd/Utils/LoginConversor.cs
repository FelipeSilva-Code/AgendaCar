using System;

namespace BackEnd.Utils
{
    public class LoginConversor
    {
        Database.LoginDatabase dbLogin = new Database.LoginDatabase();
        public Models.TbLogin ParaTbLogin(Models.Request.LoginRequest request)
        {
            Models.TbLogin tbLogin = new Models.TbLogin();

            tbLogin.DsEmail = request.Email;
            tbLogin.DsSenha = request.Senha;

            return tbLogin;
        }

        public Models.Response.LoginResponse ParaLoginResponse(Models.TbLogin request)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.IdUsuario = dbLogin.RetornarIdDoUsuario(request);

            resp.Perfil = request.DsPerfil;

            resp.Foto = dbLogin.RetornarFotoDoUsuario(request);

            return resp;
        }
    }
}