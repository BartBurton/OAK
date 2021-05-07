using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAK.Controllers
{
    public class ReturnController : Controller
    {
        public IActionResult ToSource(int source)
        {
            return View(source);
        }
    }
}
