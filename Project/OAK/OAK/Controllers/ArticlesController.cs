using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly OAKContext _oak;

        private const int _countOfEl = 10;
        private int _start = 0;
        private int Start
        {
            get => _start;
            set => _start = (value >= 0) ? value : 0;
        }


        public ArticlesController(OAKContext oak)
        {
            _oak = oak;
        }


        public IActionResult Articles(int start = 0)
        {
            Start = start;

            var articles = _oak.Articles.Skip(Start * _countOfEl).Take(_countOfEl);

            ViewBag.Title = "Статьи ДУБа";
            ViewData["Start"] = ++Start;

            return View(articles);
        }

        public IActionResult CreatedArticles(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult FavoriteArticles(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult ArticlesSection(long? id, int start = 0)
        {
            Start = start;
            return View();
        }


        public IActionResult NewsArticleseFromFavorite(long? id, int start = 0)
        {
            Start = start;
            return View("Articles");
        }
    }
}
