using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class SectionsController : Controller
    {
        private readonly OAKContext _oak;
        private const int _countOfEl = 20;

        public SectionsController(OAKContext oak)
        {
            _oak = oak;
        }

        public async Task<IActionResult> Section(long? id)
        {
            Section model = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
            if (model == null) return RedirectToAction("News", "Articles");

            _oak.Entry(model).Reference(m => m.Parent).Load();
            _oak.Entry(model).Reference(m => m.Autor).Load();

            model.Children = await _oak.Sections
                .Where(s => s.ParentID == model.ID)
                .OrderByDescending(s => s.Articles.Count)
                .Take(5)
                .Include(s => s.Autor)
                .ToListAsync();

            model.Articles = await _oak.Articles
                .Where(a => a.SectionID == model.ID)
                .OrderByDescending(a => a.Date)
                .Take(3)
                .Include(a => a.Autor)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            ViewBag.CountOfArticles = _oak.Articles.Where(a => a.SectionID == model.ID).Count();

            return View(model);
        }

        public async Task<IActionResult> All(int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "All";

            var sections = await _oak.Sections
                .OrderByDescending(s => s.Articles.Count)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(s => s.Parent)
                .Include(s => s.Autor)
                .ToListAsync();

            return View("Sections", sections);
        }

        public async Task<IActionResult> CreatedSections(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "CreatedSections";

            var sections = await _oak.Sections
                .Where(s => s.AutorID == id)
                .OrderByDescending(s => s.Articles.Count)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(s => s.Parent)
                .Include(s => s.Autor)
                .ToListAsync();

            return View("Sections", sections);
        }

        public async Task<IActionResult> SectionsRelatives(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "SectionsRelatives";

            var sections = await _oak.Sections
                .Where(s => s.ParentID == id)
                .OrderByDescending(s => s.Articles.Count)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(s => s.Parent)
                .Include(s => s.Autor)
                .ToListAsync();

            return View("Sections", sections);
        }
    }
}