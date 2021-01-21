﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult SectionFAvorite()
        {
            return View();
        }

        public IActionResult SectionParent()
        {
            return View();
        }

        public IActionResult SectionChildren()
        {
            return View();
        }
    }
}
