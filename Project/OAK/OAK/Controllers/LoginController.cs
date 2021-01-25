using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAK.Models.Login;
using OAK.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            ViewBag.Title = "Регистрация";

            if(!ModelState.IsValid)
            {
                return View();
            }
            if (await CheckEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Пользователь с данной электронной почтой уже зарегистрирован!");
                return View();
            }
            if (await CheckPassword(model.Password))
            {
                ModelState.AddModelError("Password", "Данный пароль уже используется!");
                return View();
            }

            Autor autor = new Autor();
            autor.Name = model.Name;
            autor.Email = model.Email;
            autor.Password = model.Password;
            autor.Idavatar = Guid.NewGuid();
            using (BinaryReader br = new BinaryReader(new FileStream("wwwroot/icons/acorn.png", FileMode.Open)))
            {
                autor.Avatar = br.ReadBytes((int)br.BaseStream.Length);
            }
            _oak.Autors.Add(autor);
            _oak.SaveChanges();
            await Authenticate(model.Email);

            return RedirectToAction("Articles", "Articles");
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.Title = "Вход ДУБ";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SingInModel model)
        {
            ViewBag.Title = "Вход ДУБ";

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (! await CheckEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Электронная почта не найдена!");
                return View();
            }
            if (! await CheckEmailPassword(model.Email, model.Password))
            {
                ModelState.AddModelError("Password", "Неверный пароль!");
                return View();
            }

            await Authenticate(model.Email);

            return RedirectToAction("Articles", "Articles");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.Title = "Восстановление пароля";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(EmailModel model)
        {
            ViewBag.Title = "Восстановление пароля";

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (! await CheckEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Электронная почта не найдена!");
                return View();
            }

            return View("Code");
        }


        [HttpGet]
        public IActionResult Code()
        {
            ViewBag.Title = "Проверка кода";

            return View();
        }

        [HttpPost]
        public IActionResult Code(CodeModel model)
        {
            ViewBag.Title = "Проверка кода";

            if (!ModelState.IsValid)
            {
                return View();
            }

            return View("NewPassword");
        }


        [HttpGet]
        public IActionResult NewPassword()
        {
            ViewBag.Title = "Смена пароля";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPassword(NewPasswordModel model)
        {
            ViewBag.Title = "Смена пароля";

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!await CheckEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Электронная почта не найдена!");
                return View();
            }
            if (await CheckPassword(model.Password))
            {
                ModelState.AddModelError("Password", "Данный пароль уже используется!");
                return View();
            }

            Autor autor = await _oak.Autors.FirstAsync(a => a.Email == model.Email);
            autor.Password = model.Password;
            _oak.SaveChanges();

            await Authenticate(model.Email);

            return RedirectToAction("Articles", "Articles");
        }



        private Task<bool> CheckEmail(string email) => _oak.Autors.AnyAsync(a => a.Email == email);

        private Task<bool> CheckPassword(string password) => _oak.Autors.AnyAsync(a => a.Password == password);

        private Task<bool> CheckEmailPassword(string email, string password) => 
            _oak.Autors.AnyAsync(a => a.Email == email && a.Password == password);


        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>() { new Claim(ClaimsIdentity.DefaultNameClaimType, email) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }
    }
}
