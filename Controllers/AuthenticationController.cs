using Microsoft.AspNetCore.Mvc;
using PBLSecurity.Models;
using PBLSecurity.Services;
using PBLSecurity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Common;

namespace PBLSecurity.Controllers
{
    [Route("api/authentication")]
    [ApiController]

    public class AuthenticationController : Controller
    {

        private IMockAuthentication _auth;

        public AuthenticationController()
        {
            _auth = new MockAuthentication();
        }

        [HttpPost("checkSSO")]
        public IActionResult CheckPost([FromBody] AuthenticationModel data)
        {
            
            bool isChecked = _auth.CheckAuth(data.email, data.token);

            if (isChecked == false)
                return StatusCode(404);

            return StatusCode(200, isChecked);
        }
    }
}
