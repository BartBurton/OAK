using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OAK.Models;
using Microsoft.AspNetCore.Mvc;

namespace OAK.Models.Login
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Придумайте псевдоним!")]
        [MaxLength(16, ErrorMessage = "Не больше 16 символов!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите свою электронную почту!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректная электронная почта!")]
        [MaxLength(128, ErrorMessage = "Не больше 128 символов!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Придумайте пароль!")]
        [DataType(DataType.Password)]
        [MaxLength(64, ErrorMessage = "Не больше 64 символов!")]
        [MinLength(4, ErrorMessage = "Не меньше 4 символов!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }


        public void ToAutor(ref Autor autor)
        {
            autor.Name = Name;
            autor.Email = Email;
            autor.Password = Password;
            autor.Idavatar = Guid.NewGuid();
            using (BinaryReader br = new BinaryReader(new FileStream("wwwroot/icons/user.png", FileMode.Open)))
            {
                autor.Avatar = br.ReadBytes((int)br.BaseStream.Length);
            }
        }
    }
}
