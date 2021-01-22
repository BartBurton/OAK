using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OAK.Models.Login
{
    public class RegistrationModel
    {
        [Required]
        [MaxLength(16, ErrorMessage = "Не больше 16 символов!")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный email!")]
        [MaxLength(128, ErrorMessage = "Не больше 128 символов!")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(64, ErrorMessage = "Не больше 64 символов!")]
        [MinLength(4, ErrorMessage = "Не меньше 4 символов!")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
