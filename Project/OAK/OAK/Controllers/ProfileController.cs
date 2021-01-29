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

            autor.Articles = _oak.Articles.Where(a => a.Idautor == autor.Id)
                .OrderBy(a => a.Date)
                .Take(3)
                .Include(a => a.IdsectionNavigation)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToList();

            autor.FavArticles = _oak.FavArticles.Where(f => f.Idautor == autor.Id)
                .Take(3)
                .Include(f => f.IdarticleNavigation)
                    .ThenInclude(a => a.IdsectionNavigation)
                .Include(f => f.IdarticleNavigation)
                    .ThenInclude(a => a.ArtTexts.Take(1))
                .Include(f => f.IdarticleNavigation)
                    .ThenInclude(a => a.ArtImages.Take(1))
                .ToList();

            _oak.Entry(autor).Collection(a => a.FavAutorIdautorfavoriteNavigations).Load();
            _oak.Entry(autor).Collection(a => a.FavAutorIdautororiginNavigations).Load();
            _oak.Entry(autor).Collection(a => a.FavSections).Load();
            
            _oak.Entry(autor).Collection(a => a.Sections).Load();

            return View(autor);
        }
    }
}
