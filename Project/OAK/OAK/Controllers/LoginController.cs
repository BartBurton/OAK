using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using OAK.Models;
using OAK.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OAK.Controllers
{
    public class LoginController : Controller
    {
        private readonly OAKContext _oak;
        public LoginController(OAKContext oak)
        {
            _oak = oak;
        }

        /// <summary>
        /// GET - Регистрация нового пользователя. Ввод необходимых данных.
        /// </summary>
        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.Title = "Регистрация";
            return View();
        }

        /// <summary>
        /// POST - Регистрация нового пользователя. Проверка введенных данных.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
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
            model.ToAutor(ref autor);

            await _oak.Autors.AddAsync(autor);
            _oak.SaveChanges();

            await Authenticate(model.Email);

            return RedirectToAction("News", "Articles");
        }

        /// <summary>
        /// GET - Вход на сайт. Ввод данных для входа.
        /// </summary>
        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.Title = "Вход ДУБ";
            return View();
        }

        /// <summary>
        /// POST - Вход на сайт. Проверка введенных данных.
        /// </summary>
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

            return RedirectToAction("News", "Articles");
        }


        /// <summary>
        /// GET - Первый шаг изменения пароля. Ввод электронной почты.
        /// </summary>
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.Title = "Восстановление пароля";
            return View();
        }

        /// <summary>
        /// POST - Первый шаг изменения пароля. Проверка электронной почты.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
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

        /// <summary>
        /// GET - Второй шаг изменения пароля. Отправка кода на почту пользователя.
        /// </summary>
        [HttpGet]
        public IActionResult Code()
        {
            ViewBag.Title = "Проверка кода";
            return View();
        }

        /// <summary>
        /// POST - Второй шаг изменения пароля. Проверка кода.
        /// </summary>
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

        /// <summary>
        /// GET - Трейтий шаг изменения пароля. Изменение.
        /// </summary>
        [HttpGet]
        public IActionResult NewPassword()
        {
            ViewBag.Title = "Смена пароля";
            return View();
        }

        /// <summary>
        /// POST - Трейтий шаг изменения пароля. Приминение изменений.
        /// </summary>
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

            return RedirectToAction("News", "Articles");
        }

        /// <summary>
        /// Выход пользователя.
        /// </summary>
        public new async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Login");
        }


        /// <summary>
        /// Проверка существования введенной электронной почты в базе.
        /// </summary>
        private Task<bool> CheckEmail(string email) => _oak.Autors.AnyAsync(a => a.Email == email);
        /// <summary>
        /// Проверка существования введенного пароля.
        /// </summary>
        private Task<bool> CheckPassword(string password) => _oak.Autors.AnyAsync(a => a.Password == password);
        /// <summary>
        /// Проверка существования автора с данной электронной почтой и паролем.
        /// </summary>
        private Task<bool> CheckEmailPassword(string email, string password) => 
            _oak.Autors.AnyAsync(a => a.Email == email && a.Password == password);

        /// <summary>
        /// Аутентификация пользователя.
        /// </summary>
        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>() { new Claim(ClaimsIdentity.DefaultNameClaimType, email) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, 
                "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(identity));
        }
    }
}
