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

        public ArticlesController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Articles(int start = 0)
        {
            
           if (start < 0) start = 0;

            var articles = _oak.Articles.Skip(start * _countOfEl).Take(_countOfEl);

            ViewBag.Title = "Статьи ДУБа";
            ViewData["Start"] = ++start;

            return View(articles);
        }

        public IActionResult ArticlesAutor(long? id, int start)
        {
            return View();
        }

        public IActionResult ArticlesSection(long? id, int start)
        {
            return View();
        }

        public IActionResult ArticlesFavorite(long? id, int start)
        {
            return View();
        }
    }
}
