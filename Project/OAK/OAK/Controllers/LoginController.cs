using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class LoginController : Controller
    {
        private readonly OAKContext _oak;

        public LoginController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Registration()
        {
            return View();
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
