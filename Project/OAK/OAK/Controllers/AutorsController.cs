using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using System.Linq;
using System.Threading.Tasks;

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
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.ID == id);
            if (autor == null) return RedirectToAction("News", "Articles");

            autor.Articles = await _oak.Articles.Where(a => a.AutorID == autor.ID)
                .OrderByDescending(a => a.Date).Take(3)
                .Include(a => a.Section)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            autor.Sections = await _oak.Sections.Where(s => s.AutorID == autor.ID).Take(5)
                .Include(s => s.Parent)
                .ToListAsync();

            ViewBag.CountOfArticles = _oak.Articles.Where(a => a.AutorID == autor.ID).Count();
            ViewBag.CountOfSections = _oak.Sections.Where(a => a.AutorID == autor.ID).Count();

            return View(autor);
        }
    }
}