using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class ArticleController : Controller
    {
        private readonly OAKContext _oak;

        public ArticleController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Article(long? id)
        {
            return View();
        }
    }
}
