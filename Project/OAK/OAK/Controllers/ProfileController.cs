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
    public class ProfileController : Controller
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

            _oak.Entry(autor).Collection(a => a.FavAutorIdautorfavoriteNavigations).Load();
            _oak.Entry(autor).Collection(a => a.FavAutorIdautororiginNavigations).Load();
            _oak.Entry(autor).Collection(a => a.FavSections).Load();
            _oak.Entry(autor).Collection(a => a.FavArticles).Load();
            _oak.Entry(autor).Collection(a => a.Articles).Load();
            _oak.Entry(autor).Collection(a => a.Sections).Load();

            return View(autor);
        }
    }
}
