using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Graduation.BLL.BLContracts;
using Graduation.BLL.BL;
using Graduation.Entities;

namespace Graduation.WebAPI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/api/SignIn/{email}/{password}")]
        public IActionResult PostAuthentication(string email, string password)
        {

            AccountBL accountBL = new AccountBL();
            AccountEntity accountEntity =  accountBL.Authentication(email, password);

            return Ok(accountEntity);
        }
    }
}