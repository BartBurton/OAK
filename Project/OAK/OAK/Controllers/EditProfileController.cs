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

        public async Task<IActionResult> EditProfile()
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            ProfileEditedModel model = new ProfileEditedModel()
            {
                Name = autor.Name,
                Status = autor.Status,
                AvatarBinary = autor.Avatar
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileEditedModel model)
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);

            autor.Name = model.Name;
            autor.Status = model.Status;

            if (model.Avatar != null)
            {
                using (BinaryReader br = new BinaryReader(model.Avatar.OpenReadStream()))
                {
                    autor.Avatar = br.ReadBytes((int)model.Avatar.Length);
                } 
            }

            _oak.SaveChanges();

            return RedirectToAction("Profile", "Profile");
        }

        public async Task<IActionResult> DropProfile()
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);

            _oak.Autors.Remove(autor);
            _oak.SaveChanges();

            return RedirectToAction("Logout", "Login");
        }
    }
}
