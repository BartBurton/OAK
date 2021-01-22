using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAK.Models.Login;

namespace OAK.Controllers
{
    public class LoginController : Controller
    {
        private readonly OAKContext _oak;

        public LoginController(OAKContext oak)
        {
            _oak = oak;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel rmodel)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }

        public IActionResult NewPassword()
        {
            return View();
        }
    }
}
