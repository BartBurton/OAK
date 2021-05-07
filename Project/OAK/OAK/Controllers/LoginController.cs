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
using System.Numerics;
using MimeKit;
using MailKit.Net.Smtp;
using System.Text;

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
            ViewBag.Title = "ДУБ - Регистрация";
            return View();
        }

        /// <summary>
        /// POST - Регистрация нового пользователя. Проверка введенных данных.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            ViewBag.Title = "ДУБ - Регистрация";
            if(!ModelState.IsValid)
            {
                return View();
            }
            if (await CheckEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Пользователь с данной электронной почтой уже зарегистрирован!");
                return View();
            }

            Autor autor = new Autor();
            model.ToAutor(ref autor);

            await _oak.Autors.AddAsync(autor);
            _oak.SaveChanges();

            await Authenticate(model.Email);

            return RedirectToAction("All", "Articles");
        }

        /// <summary>
        /// GET - Вход на сайт. Ввод данных для входа.
        /// </summary>
        [HttpGet]
        public IActionResult SignIn()
        {
            ViewBag.Title = "ДУБ - Вход";
            return View();
        }

        /// <summary>
        /// POST - Вход на сайт. Проверка введенных данных.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SignIn(SingInModel model)
        {
            ViewBag.Title = "ДУБ - Вход";
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

            return RedirectToAction("All", "Articles");
        }


        /// <summary>
        /// GET - Первый шаг изменения пароля. Ввод электронной почты.
        /// </summary>
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.Title = "ДУБ - Смена пароля";
            return View();
        }

        /// <summary>
        /// POST - Первый шаг изменения пароля. Проверка электронной почты.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            ViewBag.Title = "ДУБ - Смена пароля";
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (! await CheckEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Электронная почта не найдена!");
                return View();
            }

            var autor = await _oak.Autors.FirstAsync(m => m.Email == model.Email);
            autor.Code = GenerateCode();
            await _oak.SaveChangesAsync();
            SendCode(autor);

            HttpContext.Session.Set("Autor", Encoding.UTF8.GetBytes(autor.Email));    


            return View("Code");
        }

        private void SendCode(Autor autor)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("OAK", "oak_art@mail.ru"));
            message.To.Add(new MailboxAddress(autor.Name, autor.Email));
            message.Subject = "Сообщение от OAK! Код для смены пароля!";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = 
                $"<div style=\"color:#B1FFC3; font-size:40pt; background-color:#747A8D; " +
                                $"padding: 50px; text-align:center;\">" +
                    $"{autor.Code}" +
                $"</div>"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.ru", 465, true);
                client.Authenticate("oak_art@mail.ru", "r^1iuUigEPP3");
                client.Send(message);

                client.Disconnect(true);
            }
        }

        private string GenerateCode()
        {
            int code = 846221;

            Random random = new Random();

            int _1 = random.Next(100000, 999999) - DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Day;
            int _2 = random.Next(10000, 99999) - DateTime.Now.Millisecond * DateTime.Now.Second;
            int _3 = random.Next(1000, 9999) - DateTime.Now.Millisecond;
            int _4 = random.Next(100, 999) - DateTime.Now.Second * DateTime.Now.Month;
            int _5 = random.Next(10, 99) - DateTime.Now.Second;
            int _6 = random.Next(1, 9) - (DateTime.Now.Year % 1000) % 10;

            _1 = (int)Math.Abs(_1);
            _2 = (int)Math.Abs(_2);
            _3 = (int)Math.Abs(_3);
            _4 = (int)Math.Abs(_4);
            _5 = (int)Math.Abs(_5);
            _6 = (int)Math.Abs(_6);

            BigInteger key = (int)Math.Abs((short)code * (short)_1 * (short)_2 * _3 * _4 * _5 * _6);
            string str = key.ToString();
            string skey = "";
            for (int i = 0; i < 6; i++)
            {
                skey += str[random.Next(0, str.Length)];
            }
            
            return skey;
        }


        /// <summary>
        /// GET - Второй шаг изменения пароля. Отправка кода на почту пользователя.
        /// </summary>
        [HttpGet]
        public IActionResult Code()
        {
            ViewBag.Title = "ДУБ - Смена пароля";
            return View();
        }

        /// <summary>
        /// POST - Второй шаг изменения пароля. Проверка кода.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Code(CodeModel model)
        {
            ViewBag.Title = "ДУБ - Смена пароля";
            if (!ModelState.IsValid)
            {
                return View();
            }
            byte[] emailByte;
            if(!HttpContext.Session.TryGetValue("Autor", out emailByte))
            {
                ModelState.AddModelError("Code", "Время сессии истекло! Начните с предыдущего шага!");
                return View();
            }

            string email = Encoding.UTF8.GetString(emailByte);
            var autor = await _oak.Autors.FirstAsync(a => a.Email == email);
            if (autor.Code != model.Code)
            {
                ModelState.AddModelError("Code", "Неверный код!");
                return View();
            }
            autor.Code = null;
            _oak.SaveChanges();

            return View("NewPassword");
        }

        /// <summary>
        /// GET - Трейтий шаг изменения пароля. Изменение.
        /// </summary>
        [HttpGet]
        public IActionResult NewPassword()
        {
            ViewBag.Title = "ДУБ - Смена пароля";
            return View();
        }

        /// <summary>
        /// POST - Трейтий шаг изменения пароля. Приминение изменений.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> NewPassword(NewPasswordModel model)
        {
            ViewBag.Title = "ДУБ - Смена пароля";
            if (!ModelState.IsValid)
            {
                return View();
            }

            byte[] emailByte;
            if (!HttpContext.Session.TryGetValue("Autor", out emailByte))
            {
                ModelState.AddModelError("Password", "Отказано в смене пароля!");
                ModelState.AddModelError("ConfirmPassword", "Время сессии истекло или выполнен несанкционированный доступ!");
                return View();
            }

            HttpContext.Session.Clear();
            string email = Encoding.UTF8.GetString(emailByte);
            var autor = await _oak.Autors.FirstAsync(a => a.Email == email);
            if(autor.Code != null)
            {
                ModelState.AddModelError("Password", "Отказано в смене пароля!");
                ModelState.AddModelError("ConfirmPassword", "Время сессии истекло или выполнен несанкционированный доступ!");
                return View();
            }

            autor.Password = model.Password;
            _oak.SaveChanges();

            await Authenticate(autor.Email);

            return RedirectToAction("All", "Articles");
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
