using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace OAK.Models.Edited
{
    public class ProfileEditedModel
    {
        [Required(ErrorMessage = "Заполните поле псевдонима!")]
        [MaxLength(16, ErrorMessage = "Не больше 16 символов!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле статуса!")]
        [MaxLength(24, ErrorMessage = "Не больше 24 символов!")]
        public string Status { get; set; }

        public IFormFile Avatar { get; set; }

        [Required(ErrorMessage = "Установите фото профиля!")]
        public byte[] AvatarBinary { get; set; }
    }
}
