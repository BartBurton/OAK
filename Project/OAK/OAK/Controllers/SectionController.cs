using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class SectionController : Controller
    {
        private readonly OAKContext _oak;

        public SectionController(OAKContext oak)
        {
            _oak = oak;
        }

        public IActionResult Section()
        {
            return View();
        }
    }
}
