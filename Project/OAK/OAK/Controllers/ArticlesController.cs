using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using OAK.Models;
using OAK.Models.Edited;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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


        public IActionResult Article(long? id)
        {
            return View();
        }



        public IActionResult News(int start = 0)
        {
            start = (start >= 0) ? start : 0;

            ViewBag.Title = "Статьи ДУБа";

            var articles = _oak.Articles
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.IdautorNavigation)
                .Include(a => a.IdsectionNavigation)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToList();

            ViewBag.Start = start; 



            return View(articles);
        }


        public IActionResult CreatedArticles(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;


            return View();
        }


        public IActionResult FavoriteArticles(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;

            return View();
        }


        public IActionResult ArticlesSection(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;

            return View();
        }


        public IActionResult NewsFavorite(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;


            return View();
        }
    }
}
