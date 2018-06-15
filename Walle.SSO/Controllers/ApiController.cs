using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Walle.SSO.Models;

namespace Walle.SSO.Controllers
{
    [Route("/api")]
    public class ApiController : Controller
    {
        [HttpPost("signin")]
        public IActionResult SignIn(SignInModel sign)
        {
            
        }
    }
}
