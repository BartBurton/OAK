using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OAK.Models.Login
{
    public class NewPasswordModel
    {
        [Required(ErrorMessage = "Укажите свою электронную почту!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Некорректная электронная почта!")]
        [MaxLength(128, ErrorMessage = "Не больше 128 символов!")]
        [Remote(action: "CheckEmail", controller: "Registration",
            HttpMethod = "POST",
            ErrorMessage = "Пользователь с данной электронной почтой уже зарегистрирован!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Придумайте пароль!")]
        [DataType(DataType.Password)]
        [MaxLength(64, ErrorMessage = "Не больше 64 символов!")]
        [MinLength(4, ErrorMessage = "Не меньше 4 символов!")]
        [Remote(action: "CheckPassword", controller: "Registration",
            HttpMethod = "POST",
            ErrorMessage = "Данный пароль уже используется!")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmNewPassword { get; set; }
    }
}
