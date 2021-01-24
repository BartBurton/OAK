using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OAK.Models;
using Microsoft.EntityFrameworkCore;

namespace OAK.Controllers
{
    public class StartController : Controller
    {
        private readonly OAKContext _oak;

        public StartController(OAKContext oak)
        {
            _oak = oak;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
                if (autor != null)
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream("wwwroot/icons/user.png", FileMode.OpenOrCreate)))
                    {
                        bw.Write(autor.Avatar);
                    }
                }
            }


            return RedirectToAction("Articles", "Articles");
        }
    }
}
