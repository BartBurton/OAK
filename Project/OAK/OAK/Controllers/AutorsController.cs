using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class AutorsController : Controller
    {
        private readonly OAKContext _oak;

        private const int _countOfEl = 20;
        private int _start = 0;
        private int Start
        {
            get => _start;
            set => _start = (value >= 0) ? value : 0;
        }


        public AutorsController(OAKContext oak)
        {
            _oak = oak;
        }


        public IActionResult FavoriteAutors(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult AutorInFavorites(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult ArticleInFavorites(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult SectionInFavorites(long? id, int start = 0)
        {
            Start = start;
            return View();
        }
    }
}
