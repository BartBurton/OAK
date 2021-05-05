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

            await _oak.Entry(autor).Collection(a => a.Articles)
                .Query()
                .OrderByDescending(ar => ar.Date)
                .Take(3)
                .Include(ar => ar.Section)
                .Include(ar => ar.ArtTexts.Take(1))
                .Include(ar => ar.ArtImages.Take(1))
                .LoadAsync();

            await _oak.Entry(autor).Collection(a => a.Sections)
                .Query()
                .Include(s => s.Parent)
                .LoadAsync();

            ViewBag.CountOfArticles = _oak.Articles.Where(a => a.AutorID == autor.ID).Count();
            ViewBag.CountOfSections = _oak.Sections.Where(a => a.AutorID == autor.ID).Count();

            ViewBag.Title = $"Автор - {autor.Name}";
            return View(autor);
        }
    }
}