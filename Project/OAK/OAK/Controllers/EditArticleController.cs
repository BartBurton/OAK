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
            ViewData["Sections"] = _oak.Sections.ToList();
            return View();
        }


        public IActionResult EditArticle(long? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditCreateArticle(long? id)
        {
            var x = HttpContext.Request.Form;
            return View();
        }

        public IActionResult DropCreateArticle()
        {
            return View();
        }

        public IActionResult DropEditArticle()
        {
            return View();
        }
    }
}
