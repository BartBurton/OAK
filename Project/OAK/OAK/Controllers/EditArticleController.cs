using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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

        public IActionResult CreateArticle()
        {
            return View();
        }

        public IActionResult EditArticle(long? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditCreateArticle(long? id)
        {
            return View();
        }

        public IActionResult DropArticle(long? id)
        {
            return View();
        }
    }
}
