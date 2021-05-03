using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OAK.Models;
using OAK.Models.Edited;
using Microsoft.EntityFrameworkCore;

namespace OAK.Controllers
{
    [Authorize]
    public class EditProfileController : Controller
    {
        private readonly OAKContext _oak;

        public EditProfileController(OAKContext oak)
        {
            _oak = oak;
        }

        public async Task<IActionResult> Edit()
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            ProfileEditedModel model = new ProfileEditedModel();
            model.FromAutor(autor);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileEditedModel model)
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            model.ToAutor(ref autor);

            _oak.SaveChanges();

            return RedirectToAction("Autor", "Autors", new { autor.ID });
        }

        public async Task<IActionResult> Drop()
        {
            Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                .FirstOrDefaultAsync();

            _oak.Autors.Remove(autor);
            _oak.SaveChanges();

            return RedirectToAction("SignOut", "Login");
        }
    }
}
