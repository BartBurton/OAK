using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class SectionsController : Controller
    {
        private readonly OAKContext _oak;

        private const int _countOfEl = 5;
        private int _start = 0;
        private int Start 
        {
            get => _start;
            set => _start = (value >= 0) ? value : 0;
        }


        public SectionsController(OAKContext oak)
        {
            _oak = oak;
        }


        public IActionResult Sections(int start = 0)
        {
            Start = start;

            return View();
        }

        public IActionResult FavoriteSections(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult CreatedSections(long? id, int start = 0)
        {
            Start = start;
            return View();
        }

        public IActionResult SectionsRelatives(long? id, int start = 0)
        {
            Start = start;
            return View();
        }
    }
}
