using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OAK.Controllers
{
    [Authorize]
    public class EditSectionController : Controller
    {
        private readonly OAKContext _oak;

        public EditSectionController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult CreateSection()
        {
            return View();
        }

        public IActionResult EditSection(long? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditCreateSection(long? id)
        {
            return View();
        }

        public IActionResult DropSection(long? id)
        {
            return View();
        }
    }
}
