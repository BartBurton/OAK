using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OAK.Models;
using Microsoft.EntityFrameworkCore;

namespace OAK.Controllers
{
    public class ProfileController : Controller, Services.ICurrentUser
    {
        private readonly OAKContext _oak;

        public ProfileController(OAKContext oak)
        {
            _oak = oak;
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);

            if(autor == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View(autor);
        }


        public async Task<Autor> GetInformation()
        {
            Autor autor = null;

            if (User?.Identity.IsAuthenticated == true)
            {
                autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            }

            return autor;
        }
    }
}
