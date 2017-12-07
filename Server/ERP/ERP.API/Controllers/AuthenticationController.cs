using ERP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.API.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        [Route("signin")]
        [HttpPost]
        public LoginResponse SignIn([FromBody]SignInModel model)
        {
            try
            {
                var response = new Authenticator().Authenticate(model);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("test")]
        public string test()
        {
            return "Hello from server";
        }
    }
}
