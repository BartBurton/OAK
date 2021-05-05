using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using OAK.Models.Edited;
using System.Linq;
using System.Threading.Tasks;

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

            ViewBag.Title = "Редактировать профиль";
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
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            _oak.Autors.Remove(autor);
            _oak.SaveChanges();

            return RedirectToAction("SignOut", "Login");
        }
    }
}