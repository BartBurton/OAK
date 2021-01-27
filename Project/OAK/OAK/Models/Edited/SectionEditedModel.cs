using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OAK.Models;

namespace OAK.Models.Edited
{
    public class SectionEditedModel
    {
        public long? Id { get; set; } = null;

        public long? Parent { get; set; } = null;

        [Required(ErrorMessage = "Дайте название ветви!")]
        [MaxLength(32, ErrorMessage = "Не больше 32 символов!")]
        public string Name { get; set; } = "";
    }
}
