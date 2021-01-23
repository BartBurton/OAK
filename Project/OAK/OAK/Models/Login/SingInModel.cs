using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OAK.Models.Login
{
    public class SingInModel
    {
        [Required(ErrorMessage = "Укажите свою электронную почту!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Некорректная электронная почта!")]
        [MaxLength(128, ErrorMessage = "Не больше 128 символов!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите свой пароль!")]
        [DataType(DataType.Password)]
        [MaxLength(64, ErrorMessage = "Не больше 64 символов!")]
        [MinLength(4, ErrorMessage = "Не меньше 4 символов!")]
        public string Password { get; set; }
    }
}
