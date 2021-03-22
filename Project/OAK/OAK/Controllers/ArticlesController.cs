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



        public async Task<IActionResult> News(int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "News";
            ViewBag.Title = "Статьи ДУБа";

            var articles = await _oak.Articles
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.IdautorNavigation)
                .Include(a => a.IdsectionNavigation)
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
            ViewBag.Title = "Статьи ДУБа";

            var articles = await _oak.Articles
                .Where(a => a.Idautor == id)
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.IdautorNavigation)
                .Include(a => a.IdsectionNavigation)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            return View("Articles", articles);
        }


        public async Task<IActionResult> FavoriteArticles(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "FavoriteArticles";
            ViewBag.Title = "Статьи ДУБа";

            var articles = await _oak.Articles
                .Where(a => a.FavArticles.Any(fa => fa.Idarticle == a.Id))
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.IdautorNavigation)
                .Include(a => a.IdsectionNavigation)
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
            ViewBag.Title = "Статьи ДУБа";

            var articles = await _oak.Articles
                .Where(a => a.Idsection == id)
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.IdautorNavigation)
                .Include(a => a.IdsectionNavigation)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();

            return View("Articles", articles);
        }


        public async Task<IActionResult> NewsFavorite(long? id, int start = 0)
        {
            start = (start >= 0) ? start : 0;
            ViewBag.Start = start;
            ViewBag.Action = "NewsFavorite";
            ViewBag.Title = "Статьи ДУБа";

            var autors = _oak.FavAutors
                //.Where(fa => fa.Idautororigin == id)
                .Select(fa => fa.Idautororigin == id)
                .ToListAsync();

            var articles = await _oak.Articles
                .OrderByDescending(a => a.Date)
                .Skip(start * _countOfEl)
                .Take(_countOfEl)
                .Include(a => a.IdautorNavigation)
                .Include(a => a.IdsectionNavigation)
                .Include(a => a.ArtTexts.Take(1))
                .Include(a => a.ArtImages.Take(1))
                .ToListAsync();
                
            return View("Articles", articles);
        }
    }
}
