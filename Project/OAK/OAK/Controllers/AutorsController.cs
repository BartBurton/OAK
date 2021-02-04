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
    public class AutorsController : Controller
    {
        private readonly OAKContext _oak;
        private const int _countOfEl = 20;
        public AutorsController(OAKContext oak)
        {
            _oak = oak;
        }


        public async Task<IActionResult> Autor(long id)
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Id == id);
            if (autor == null) return RedirectToAction("News", "Articles");

            autor.Articles = await _oak.Articles.Where(a => a.Idautor == autor.Id)
                .OrderByDescending(a => a.Date).Take(3)
                .Include(a => a.IdsectionNavigation)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            autor.FavArticles = await _oak.FavArticles.Where(f => f.Idautor == autor.Id).Take(3)
                .Include(f => f.IdarticleNavigation).ThenInclude(a => a.IdsectionNavigation)
                .Include(f => f.IdarticleNavigation).ThenInclude(a => a.ArtTexts.Take(1))
                .Include(f => f.IdarticleNavigation).ThenInclude(a => a.ArtImages.Take(1))
                .ToListAsync();

            autor.Sections = await _oak.Sections.Where(s => s.Idautor == autor.Id).Take(5)
                .Include(s => s.IdautorNavigation)
                .Include(s => s.IdparentNavigation)
                .ToListAsync();

            _oak.Entry(autor).Collection(a => a.FavAutorIdautorfavoriteNavigations).Load();
            _oak.Entry(autor).Collection(a => a.FavAutorIdautororiginNavigations).Load();
            _oak.Entry(autor).Collection(a => a.FavSections).Load();

            return View(autor);
        }


        public IActionResult FavoriteAutors(long? id, int start = 0)
        {
            return View();
        }

        public IActionResult AutorInFavorites(long? id, int start = 0)
        {
            return View();
        }

        public IActionResult ArticleInFavorites(long? id, int start = 0)
        {
            return View();
        }

        public IActionResult SectionInFavorites(long? id, int start = 0)
        {
            return View();
        }
    }
}
