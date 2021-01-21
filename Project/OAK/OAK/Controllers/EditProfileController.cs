using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly OAKContext _oak;

        public EditProfileController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditedProfile()
        {
            return View();
        }
    }
}
