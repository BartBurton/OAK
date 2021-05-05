using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using System.Collections.Generic;
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

            await _oak.Entry(model).Reference(m => m.Parent).LoadAsync();
            await _oak.Entry(model).Reference(m => m.Autor).LoadAsync();

            await _oak.Entry(model).Collection(m => m.Children)
                .Query()
                .OrderByDescending(s => s.Articles.Count)
                .Take(5)
                .Include(s => s.Autor)
                .LoadAsync();

            await _oak.Entry(model).Collection(m => m.Articles)
                .Query()
                .OrderByDescending(a => a.Date)
                .Take(3)
                .Include(a => a.Autor)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .LoadAsync();

            ViewBag.CountOfArticles = _oak.Articles.Where(a => a.SectionID == model.ID).Count();

            ViewBag.Title = $"Ветвь - {model.Name}";
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

            ViewBag.Title = $"Все ветви";
            return View("Sections", sections);
        }

        public async Task<IActionResult> CreatedSections(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "CreatedSections";

            var autor = await _oak.Autors.FirstOrDefaultAsync(a => a.ID == id);
            if (autor is null) return View("Sections", new List<Section>());

            await _oak.Entry(autor).Collection(a => a.Sections)
                .Query()
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(s => s.Parent)
                .LoadAsync();

            ViewBag.Title = $"Ветви автора - {autor.Name}";
            return View("Sections", autor.Sections.ToList());
        }

        public async Task<IActionResult> SectionsRelatives(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "SectionsRelatives";

            var parent = await _oak.Sections.FirstOrDefaultAsync(p => p.ID == id);
            if (parent is null) return View("Sections", new List<Section>());

            await _oak.Entry(parent).Collection(a => a.Children)
                .Query()
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(s => s.Autor)
                .LoadAsync();

            ViewBag.Title = $"Дочерние ветви - {parent.Name}";
            return View("Sections", parent.Children.ToList());
        }
    }
}