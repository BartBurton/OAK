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
            ViewBag.Title = "Регистрация";
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel rmodel)
        {
            ViewBag.Title = "Регистрация";

            if(!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.Title = "Вход ДУБ";
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SingInModel smodel)
        {
            ViewBag.Title = "Вход ДУБ";

            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.Title = "Восстановление пароля";
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(EmailModel smodel)
        {
            ViewBag.Title = "Восстановление пароля";

            if (!ModelState.IsValid)
            {
                return View();
            }

            return View("Code");
        }

        [HttpPost]
        public IActionResult Code()
        {
            ViewBag.Title = "Проверка кода";

            if (!ModelState.IsValid)
            {
                return View();
            }

            return View("NewPassword");
        }

        public IActionResult NewPassword()
        {
            return View();
        }




        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
            if (_oak.Autors.Any(a => a.Email == email))
            {
                return Json(false);
            }
            return Json(true);
        }

        [HttpPost]
        public JsonResult CheckPassword(string password)
        {
            if (_oak.Autors.Any(a => a.Password == password))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
