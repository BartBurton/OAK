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

        private const int COUNT_OF_RECORDS = 20;
        private const int COUNT_OF_PAGES = 3;

        public SectionsController(OAKContext oak)
        {
            _oak = oak;
        }

        public async Task<IActionResult> Section(long? id)
        {
            Section model = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
            if (model == null) return RedirectToAction("Error", "Articles");

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

        public async Task<IActionResult> All(int page = 0)
        {
            ViewBag.Action = "All";

            var sections = await _oak.Sections
                .OrderByDescending(s => s.Articles.Count)
                .Skip(page * COUNT_OF_RECORDS)
                .Take(COUNT_OF_RECORDS)
                .Include(s => s.Parent)
                .Include(s => s.Autor)
                .ToListAsync();

            ViewBag.Current = page;

            page++;
            int pages = _oak.Sections.Count() / COUNT_OF_RECORDS;
            if (_oak.Sections.Count() % COUNT_OF_RECORDS != 0) pages++;

            ViewBag.Back = (page > COUNT_OF_PAGES) ? COUNT_OF_PAGES : page - 1;
            ViewBag.Next = (page < pages - COUNT_OF_PAGES) ? COUNT_OF_PAGES : pages - page;

            ViewBag.Title = $"Все ветви";
            return View("Sections", sections);
        }

        public async Task<IActionResult> CreatedSections(long? id, int page = 0)
        {
            ViewBag.ID = id;
            ViewBag.Action = "CreatedSections";

            var autor = await _oak.Autors.FirstOrDefaultAsync(a => a.ID == id);
            if (autor is null) return View("Sections", new List<Section>());

            await _oak.Entry(autor).Collection(a => a.Sections)
                .Query()
                .Skip(page * COUNT_OF_RECORDS)
                .Take(COUNT_OF_RECORDS)
                .LoadAsync();
            List<Section> sections = autor.Sections.ToList();
            foreach (var section in sections)
            {
                await _oak.Entry(section).Reference(s => s.Parent).LoadAsync();
            }

            ViewBag.Current = page;

            page++;
            int count = _oak.Sections.Where(a => a.AutorID == id).Count();
            int pages = count / COUNT_OF_RECORDS;
            if (count % COUNT_OF_RECORDS != 0) pages++;

            ViewBag.Back = (page > COUNT_OF_PAGES) ? COUNT_OF_PAGES : page - 1;
            ViewBag.Next = (page < pages - COUNT_OF_PAGES) ? COUNT_OF_PAGES : pages - page;

            ViewBag.Title = $"Ветви автора - {autor.Name}";
            return View("Sections", sections);
        }

        public async Task<IActionResult> SectionsRelatives(long? id, int page = 0)
        {
            ViewBag.ID = id;
            ViewBag.Action = "SectionsRelatives";

            var parent = await _oak.Sections.FirstOrDefaultAsync(p => p.ID == id);
            if (parent is null) return View("Sections", new List<Section>());

            await _oak.Entry(parent).Collection(a => a.Children)
                .Query()
                .Skip(page * COUNT_OF_RECORDS)
                .Take(COUNT_OF_RECORDS)
                .Include(s => s.Autor)
                .LoadAsync();

            ViewBag.Current = page;

            page++;
            int count = _oak.Sections.Where(s => s.ParentID == id).Count();
            int pages = count / COUNT_OF_RECORDS;
            if (count % COUNT_OF_RECORDS != 0) pages++;

            ViewBag.Back = (page > COUNT_OF_PAGES) ? COUNT_OF_PAGES : page - 1;
            ViewBag.Next = (page < pages - COUNT_OF_PAGES) ? COUNT_OF_PAGES : pages - page;

            ViewBag.Title = $"Дочерние ветви - {parent.Name}";
            return View("Sections", parent.Children.ToList());
        }
    }
}