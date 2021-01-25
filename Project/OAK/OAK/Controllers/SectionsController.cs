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

        public SectionsController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Sections()
        {
            return View();
        }

        public IActionResult FavoriteSections()
        {
            return View();
        }

        public IActionResult SectionsParent()
        {
            return View();
        }

        public IActionResult SectionsChildren()
        {
            return View();
        }
    }
}
