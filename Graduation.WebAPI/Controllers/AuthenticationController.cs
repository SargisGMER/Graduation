using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.WebAPI.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/api/SignIn")]
        public IActionResult PostSginIn()
        {


            return Ok("Hello My First API Call");
        }
    }
}