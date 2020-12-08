using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeralController : ControllerBase
    {

        Business.LoginBusiness business = new Business.LoginBusiness();
        Utils.GeralConversor conversor = new Utils.GeralConversor();


        [HttpPost("login")]
        public ActionResult<Models.Response.LoginResponse> Logar(Models.Request.LoginRequest loginRequest)
        {
            try
            {
                Models.TbLogin tbLogin = conversor.ParaTbLogin(loginRequest);
                tbLogin = business.Logar(tbLogin);

                Models.Response.LoginResponse resp = conversor.ParaLoginResponse(tbLogin);

                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(
                    400, ex.Message
                ));
            }
        }


    }
}