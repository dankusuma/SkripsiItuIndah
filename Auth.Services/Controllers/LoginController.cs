using Auth.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auth.Services.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public bool Login([FromUri]string NPM,string PASSWORD)
        {
            LoginManager lm = new LoginManager();
            return lm.Otentifikasi(NPM,PASSWORD);
        }
    }
}
