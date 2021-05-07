using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly OAKContext _oak;

        private const int COUNT_OF_RECORDS = 10;
        private const int COUNT_OF_PAGES = 3;

        public ArticlesController(OAKContext oak)
        {
            _oak = oak;
        }

        public async Task<IActionResult> Article(long? id)
        {
            var model = await _oak.Articles.FirstOrDefaultAsync(m => m.ID == id);
            if (model is null) return RedirectToAction("Error", "Articles");

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

            model.Views++;
            await _oak.SaveChangesAsync();

            ViewBag.Title = $"Статья - {model.Name}";
            return View(model);
        }


        public IActionResult ArticleIsLiked(int id)
        {
            string access = "";

            var autor = _oak.Autors.FirstOrDefault(a => a.Email == User.Identity.Name);
            if (autor is null)
            {
                access = "none";
                return Json(access);
            }

            _oak.Entry(autor).Collection(a => a.Liked).Load();
            if (autor.Liked.Any(a => a.ID == id))
            { access = "like"; }
            else
            { access = "no like"; }

            return Json(access);
        }

        public IActionResult SetLike(int id)
        {
            string access = "";
            var article = _oak.Articles.FirstOrDefault(a => a.ID == id);
            if (article == null)
            {
                access = "error";
                return Json(new { access = access });
            }
            _oak.Entry(article).Collection(m => m.Likes).Load();

            var autor = _oak.Autors.FirstOrDefault(a => a.Email == User.Identity.Name);
            if (autor is null)
            {
                access = "none";
                return Json(new { access = access, count = article.LikesCount });
            }

            _oak.Entry(autor).Collection(a => a.Liked).Load();
            if (autor.Liked.Contains(article))
            {
                autor.Liked.Remove(article);
                article.LikesCount--;
                _oak.SaveChanges();
                access = "no like";
            }
            else
            {
                autor.Liked.Add(article);
                article.LikesCount++;
                _oak.SaveChanges();
                access = "like";
            }

            return Json(new { access = access, count = article.LikesCount });
        }



        public IActionResult All(int? id, int page = 0, Sort sort = Sort.News)
        {
            ViewBag.ID = 0;
            ViewBag.Page = page;
            ViewBag.Sort = sort;
            ViewBag.Action = $"/Articles/{(nameof(All))}";
            ViewBag.Title = "Статьи";
            return View("Articles", nameof(AllArticles));
        }

        public async Task<IActionResult> AllArticles(int? id, int page = 0, Sort sort = Sort.News)
        {
            List<Article> articles;

            switch (sort)
            {
                case Sort.News:
                    articles = await _oak.Articles.OrderByDescending(a => a.Date).ToListAsync();
                    break;

                case Sort.Popular:
                    articles = await _oak.Articles.OrderByDescending(a => a.LikesCount).ToListAsync();
                    break;

                case Sort.Watched:
                    articles = await _oak.Articles.OrderByDescending(a => a.Views).ToListAsync();
                    break;

                default:
                    articles = await _oak.Articles.OrderByDescending(a => a.Date).ToListAsync();
                    break;
            }

            articles = articles
                .Skip(page * COUNT_OF_RECORDS)
                .Take(COUNT_OF_RECORDS).ToList();
            foreach (var article in articles)
            {
                await _oak.Entry(article).Reference(a => a.Autor).LoadAsync();
                await _oak.Entry(article).Reference(a => a.Section).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtTexts)
                    .Query().Take(1).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtImages)
                    .Query().Take(1).LoadAsync();
            }

            ViewBag.Current = page;

            page++;
            int pages = _oak.Articles.Count() / COUNT_OF_RECORDS;
            if (_oak.Articles.Count() % COUNT_OF_RECORDS != 0) pages++;

            ViewBag.Back = (page > COUNT_OF_PAGES) ? COUNT_OF_PAGES : page - 1;
            ViewBag.Next = (page < pages - COUNT_OF_PAGES) ? COUNT_OF_PAGES : pages - page;

            return PartialView("_ArticlesPartial", articles);
        }


        public async Task<IActionResult> Created(long? id, int page = 0, Sort sort = Sort.News)
        {
            ViewBag.ID = id;
            ViewBag.Page = page;
            ViewBag.Sort = sort;
            ViewBag.Action = $"/Articles/{(nameof(Created))}";

            var autor = await _oak.Autors.FirstOrDefaultAsync(a => a.ID == id);
            ViewBag.Title = $"Статьи автора - {(autor is null ? "*" : autor.Name)}";

            return View("Articles", nameof(CreatedArticles));
        }

        public async Task<IActionResult> CreatedArticles(long? id, int page = 0, Sort sort = Sort.News)
        {
            var autor = await _oak.Autors.FirstOrDefaultAsync(a => a.ID == id);
            if (autor is null) return PartialView("_ArticlesPartial", new List<Article>());

            List<Article> articles;
            switch (sort)
            {
                case Sort.News:
                    await _oak.Entry(autor).Collection(a => a.Articles)
                        .Query().OrderByDescending(ar => ar.Date)
                        .LoadAsync();
                    break;

                case Sort.Popular:
                    await _oak.Entry(autor).Collection(a => a.Articles)
                        .Query().OrderByDescending(a => a.LikesCount)
                        .LoadAsync();
                    break;

                case Sort.Watched:
                    await _oak.Entry(autor).Collection(a => a.Articles)
                        .Query().OrderByDescending(ar => ar.Views)
                        .LoadAsync();
                    break;

                default:
                    await _oak.Entry(autor).Collection(a => a.Articles)
                        .Query().OrderByDescending(ar => ar.Date)
                        .LoadAsync();
                    break;
            }

            articles = autor.Articles.Skip(page * COUNT_OF_RECORDS).Take(COUNT_OF_RECORDS).ToList();
            foreach (var article in articles)
            {
                await _oak.Entry(article).Reference(a => a.Autor).LoadAsync();
                await _oak.Entry(article).Reference(a => a.Section).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtTexts)
                    .Query().Take(1).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtImages)
                    .Query().Take(1).LoadAsync();
            }

            ViewBag.Current = page;

            page++;
            int pages = autor.Articles.Count() / COUNT_OF_RECORDS;
            if (autor.Articles.Count() % COUNT_OF_RECORDS != 0) pages++;

            ViewBag.Back = (page > COUNT_OF_PAGES) ? COUNT_OF_PAGES : page - 1;
            ViewBag.Next = (page < pages - COUNT_OF_PAGES) ? COUNT_OF_PAGES : pages - page;

            return PartialView("_ArticlesPartial", articles);
        }


        public async Task<IActionResult> FromSection(long? id, int page = 0, Sort sort = Sort.News)
        {
            ViewBag.ID = id;
            ViewBag.Page = page;
            ViewBag.Sort = sort;
            ViewBag.Action = $"/Articles/{(nameof(FromSection))}";

            var section = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
            ViewBag.Title = $"Статьи ветви - {(section is null ? "*" : section.Name)}";

            return View("Articles", nameof(FromSectionArticle));
        }

        public async Task<IActionResult> FromSectionArticle(long? id, int page = 0, Sort sort = Sort.News)
        {
            var section = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
            if (section is null) return PartialView("_ArticlesPartial", new List<Article>());

            List<Article> articles;
            switch (sort)
            {
                case Sort.News:
                    await _oak.Entry(section).Collection(a => a.Articles)
                        .Query().OrderByDescending(ar => ar.Date)
                        .LoadAsync();
                    break;

                case Sort.Popular:
                    await _oak.Entry(section).Collection(a => a.Articles)
                        .Query().OrderByDescending(a => a.LikesCount)
                        .LoadAsync();
                    break;

                case Sort.Watched:
                    await _oak.Entry(section).Collection(a => a.Articles)
                        .Query().OrderByDescending(ar => ar.Views)
                        .LoadAsync();
                    break;

                default:
                    await _oak.Entry(section).Collection(a => a.Articles)
                        .Query().OrderByDescending(ar => ar.Date)
                        .LoadAsync();
                    break;
            }

            articles = section.Articles.Skip(page * COUNT_OF_RECORDS).Take(COUNT_OF_RECORDS).ToList();
            foreach (var article in articles)
            {
                await _oak.Entry(article).Reference(a => a.Autor).LoadAsync();
                await _oak.Entry(article).Reference(a => a.Section).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtTexts)
                    .Query().Take(1).LoadAsync();
                await _oak.Entry(article).Collection(a => a.ArtImages)
                    .Query().Take(1).LoadAsync();
            }

            ViewBag.Current = page;

            page++;
            int pages = section.Articles.Count() / COUNT_OF_RECORDS;
            if (section.Articles.Count() % COUNT_OF_RECORDS != 0) pages++;

            ViewBag.Back = (page > COUNT_OF_PAGES) ? COUNT_OF_PAGES : page - 1;
            ViewBag.Next = (page < pages - COUNT_OF_PAGES) ? COUNT_OF_PAGES : pages - page;

            return PartialView("_ArticlesPartial", articles);
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}