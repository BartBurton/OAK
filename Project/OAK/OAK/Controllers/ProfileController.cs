using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class ProfileController : Controller
    {
        private readonly OAKContext _oak;

        public ProfileController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
