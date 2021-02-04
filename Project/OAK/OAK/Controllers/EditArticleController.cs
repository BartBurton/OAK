using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OAK.Models;
using OAK.Models.Edited;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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

        public async Task<IActionResult> EditCreate(long? id)
        {
            ViewData["Sections"] = _oak.Sections.ToList();

            ArticleEditedModel model = new ArticleEditedModel();

            if (id != null)
            {
                Article article = await _oak.Articles.Where(a => a.Id == id)
                    .Include(a => a.ArtTexts)
                    .Include(a => a.ArtSubtitles)
                    .Include(a => a.ArtImages)
                    .FirstOrDefaultAsync();

                Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                    .Include(a => a.Articles)
                    .FirstOrDefaultAsync();

                if (!ArticleEditedModel.HaveArticle(autor, article)) 
                { 
                    return RedirectToAction("Autor", "Autors", new { autor.Id }); 
                }

                model.FromArticle(article);
            }

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditCreate(long? id, ArticleEditedModel model)
        {
            model.FromRequest(Request.Form);

            if (!model.IsCorrect)
            {
                ViewData["Sections"] = _oak.Sections.ToList();
                ModelState.AddModelError("Content", "Хотя бы одно поле текста и изображения должно быть заполнено!");
                return View(model);
            }

            Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                .Include(a => a.Articles)
                .FirstOrDefaultAsync();

            Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.Id == model.Section);

            Article article = new Article();

            if (id != null)
            {
                Article deleted = await _oak.Articles.FirstOrDefaultAsync(a => a.Id == id);

                if (!ArticleEditedModel.HaveArticle(autor, deleted)) 
                { 
                    return RedirectToAction("Autor", "Autors", new { autor.Id }); 
                }

                _oak.Articles.Remove(deleted);
                _oak.SaveChanges();
            }

            model.ToArticle(article, autor, section);

            await _oak.Articles.AddAsync(article);
            _oak.SaveChanges();

            return RedirectToAction("Autor", "Autors", new { autor.Id });
        }


        public async Task<IActionResult> Drop(long? id)
        {
            if (id == null) { return RedirectToAction("News", "Articles"); }

            Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                .Include(a => a.Articles)
                .FirstOrDefaultAsync();

            Article deleted = await _oak.Articles.FirstOrDefaultAsync(a => a.Id == id);

            if (!ArticleEditedModel.HaveArticle(autor, deleted)) 
            { 
                return RedirectToAction("Autor", "Autors", new { autor.Id }); 
            }

            _oak.Articles.Remove(deleted);
            _oak.SaveChanges();

            return RedirectToAction("Autor", "Autors", new { autor.Id });
        }
    }
}
