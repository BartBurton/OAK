using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class AutorController : Controller
    {
        private readonly OAKContext _oak;

        public AutorController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Autor(long? id)
        {
            return View();
        }
    }
}
