using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OAK.Models.Login
{
    public class CodeModel
    {
        [Required(ErrorMessage = "Невереный код!")]
        [MaxLength(6, ErrorMessage = "Неверный код!")]
        [MinLength(6, ErrorMessage = "Неверный код!")]
        public string Code { get; set; }
    }
}
