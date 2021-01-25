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

        public AutorsController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult FavoriteAutors(long? id)
        {
            return View();
        }

        public IActionResult InFavorites(long? id)
        {
            return View();
        }
    }
}
