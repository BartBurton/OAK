using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly OAKContext _oak;

        private const int _countOfEl = 10;

        public ArticlesController(OAKContext oak)
        {
            _oak = oak;
        }

        public async Task<IActionResult> Article(long? id)
        {
            var model = await _oak.Articles.FirstOrDefaultAsync(m => m.ID == id);
            if (model is null) return RedirectToAction("News", "Articles");

            await _oak.Entry(model).Reference(m => m.Autor).LoadAsync();
            await _oak.Entry(model).Reference(m => m.Section).LoadAsync();
            await _oak.Entry(model).Collection(m => m.ArtTexts).LoadAsync();
            await _oak.Entry(model).Collection(m => m.ArtSubtitles).LoadAsync();
            await _oak.Entry(model).Collection(m => m.ArtImages).LoadAsync();

            List<(string Type, short Number, byte[] Data)> content = new List<(string Type, short Number, byte[] Data)>();
            content.AddRange(model.ArtTexts.Select(at => ("text", at.Number, at.Text)));
            content.AddRange(model.ArtSubtitles.Select(at => ("sub", at.Number, at.Subtitle)));
            content.AddRange(model.ArtImages.Select(at => ("img", at.Number, at.Image)));

            ViewBag.Content = content.OrderBy(e => e.Number).ToList();

            return View(model);
        }

        public async Task<IActionResult> News(int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "News";

            var articles = await _oak.Articles
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.Autor)
                .Include(a => a.Section)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            return View("Articles", articles);
        }

        public async Task<IActionResult> CreatedArticles(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "CreatedArticles";

            var articles = await _oak.Articles
                .Where(a => a.AutorID == id)
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.Autor)
                .Include(a => a.Section)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            return View("Articles", articles);
        }

        public async Task<IActionResult> ArticlesSection(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "ArticlesSection";

            var articles = await _oak.Articles
                .Where(a => a.SectionID == id)
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.Autor)
                .Include(a => a.Section)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            return View("Articles", articles);
        }
    }
}