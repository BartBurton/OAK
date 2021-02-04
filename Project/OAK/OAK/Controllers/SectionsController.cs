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
    public class SectionsController : Controller
    {
        private readonly OAKContext _oak;
        private const int _countOfEl = 20;
        public SectionsController(OAKContext oak)
        {
            _oak = oak;
        }


        public IActionResult Section(long id)
        {
            return View();
        }



        public IActionResult All(int start = 0)
        {
            start = (start >= 0) ? start : 0;

            ViewBag.Title = "Ветви";

            var sections = _oak.Sections
                .Include(s => s.Articles)
                .OrderByDescending(s => s.Articles.Count)
                .Include(s => s.IdparentNavigation)
                .Include(s => s.IdautorNavigation)
                .ToList();

            ViewBag.Start = start;

            return View(sections);
        }

        public IActionResult FavoriteSections(long? id, int start = 0)
        {
            return View();
        }

        public IActionResult CreatedSections(long? id, int start = 0)
        {
            return View();
        }

        public IActionResult SectionsRelatives(long? id, int start = 0)
        {
            return View();
        }
    }
}
