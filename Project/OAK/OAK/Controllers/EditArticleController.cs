using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using OAK.Models.Edited;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    [Authorize]
    public class EditArticleController : Controller
    {
        private readonly OAKContext _oak;

        public EditArticleController(OAKContext oak)
        {
            _oak = oak;
        }

        [HttpGet]
        public async Task<IActionResult> EditCreate(long? id)
        {
            ArticleEditedModel model = new ArticleEditedModel();
            Section section = await _oak.Sections.FirstAsync();
            model.Section = section.ID;
            ViewBag.SectionName = section.Name;

            if (id != null)
            {
                var autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
                if (autor is null) return RedirectToAction("All", "Articles"); 

                var article = await _oak.Articles.FirstOrDefaultAsync(a => a.ID == id);
                if (article is null) return RedirectToAction("Error", "Articles");

                if (autor.ID != article.AutorID) return RedirectToAction("Autor", "Autors", new { autor.ID }); 


                _oak.Entry(article).Collection(a => a.ArtTexts).Load();
                _oak.Entry(article).Collection(a => a.ArtSubtitles).Load();
                _oak.Entry(article).Collection(a => a.ArtImages).Load();

                await _oak.Entry(article).Reference(s => s.Section).LoadAsync();
                ViewBag.SectionName = article.Section.Name;

                model.FromArticle(article);
            }
            ViewBag.Source = -1;
            ViewBag.Title = "Работа над статьей";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCreate(long? id, int source, ArticleEditedModel model)
        {
            ViewBag.Source = source;
            model.FromRequest(Request.Form);

            if (!model.IsCorrect)
            {
                ModelState.AddModelError("Content", "Хотя бы одно поле текста и изображения должно быть заполнено!");

                Section selected = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Section);
                ViewBag.SectionName = (selected is null) ? "..." : selected.Name;

                ViewBag.Title = "Работа над статьей";
                return View(model);
            }

            var autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            if (autor is null) return RedirectToAction("All", "Articles");

            Article article = new Article();
            article.Date = DateTime.Now;

            if (id != null)
            {
                article = await _oak.Articles.FirstOrDefaultAsync(a => a.ID == id);

                if (autor.ID != article.AutorID) return RedirectToAction("Autor", "Autors", new { autor.ID }); 

                await _oak.Entry(article).Collection(a => a.ArtTexts).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtSubtitles).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtImages).LoadAsync();

                _oak.ArtTexts.RemoveRange(article.ArtTexts);
                _oak.ArtSubtitles.RemoveRange(article.ArtSubtitles);
                _oak.ArtImages.RemoveRange(article.ArtImages);
            }

            model.ToArticle(article, autor);
            if (id is null)
            {
                await _oak.Articles.AddAsync(article);
            }
            _oak.SaveChanges();


            //////////////////////
            return RedirectToAction("ToSource", "Return", new { source });
        }


        public async Task<IActionResult> Drop(long? id, int source)
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            if (autor is null) return RedirectToAction("All", "Articles");

            Article deleted = await _oak.Articles.FirstOrDefaultAsync(a => a.ID == id);
            if (deleted is null) return RedirectToAction("Error", "Articles");

            if (autor.ID != deleted.AutorID) return RedirectToAction("Autor", "Autors", new { autor.ID });

            _oak.Articles.Remove(deleted);
            _oak.SaveChanges();


            //////////////////////
            return RedirectToAction("ToSource", "Return", new { source });
        }
    }
}