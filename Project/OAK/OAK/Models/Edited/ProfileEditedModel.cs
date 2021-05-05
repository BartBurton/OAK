using System;
using System.IO;
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

        [MaxLength(24, ErrorMessage = "Не больше 24 символов!")]
        public string Status { get; set; }

        public IFormFile Avatar { get; set; }

        [Required(ErrorMessage = "Установите фото профиля!")]
        public byte[] AvatarBinary { get; set; }


        public void FromAutor(Autor autor)
        {
            Name = autor.Name;
            Status = autor.Status;
            AvatarBinary = autor.Avatar;
        }

        public void ToAutor(ref Autor autor)
        {
            autor.Name = Name;
            autor.Status = Status;
            if(Avatar != null)
            {
                using (BinaryReader br = new BinaryReader(Avatar.OpenReadStream()))
                {
                    autor.Avatar = br.ReadBytes((int)Avatar.Length);
                }   
            }
        }
    }
}
