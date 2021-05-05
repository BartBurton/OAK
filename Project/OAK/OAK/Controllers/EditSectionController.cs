using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAK.Models;
using OAK.Models.Edited;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> EditCreate(long? id)
        {
            List<Section> sections = await _oak.Sections.ToListAsync();
            SectionEditedModel model = new SectionEditedModel();

            if (id != null)
            {
                Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
                if (autor is null) RedirectToAction("News", "Articles");

                Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
                if (section is null) RedirectToAction("News", "Articles");

                if (!SectionEditedModel.HaveSection(autor, section))
                {
                    return RedirectToAction("Autor", "Autors", new { autor.ID });
                }

                model.FromSection(section);
                model.RemoveChildren(sections);
            }

            ViewData["Sections"] = sections;
            ViewBag.Title = "Работа над ветвью";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCreate(long? id, SectionEditedModel model)
        {
            List<Section> sections = await _oak.Sections.ToListAsync();
            if (id != null)
            {
                model.RemoveChildren(sections);
            }
            ViewData["Sections"] = sections;

            if (!model.IsUnique(await _oak.Sections.ToListAsync()))
            {
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Данная ветвь уже существует! Измените предка или название!");
                ViewBag.Title = "Работа над ветвью";
                return View(model);
            }
            if (!model.IsCorrect(await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent)))
            {
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Родительская и дочерняя ветви не могут совпадать!");
                ViewBag.Title = "Работа над ветвью";
                return View(model);
            }

            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            _oak.Entry(autor).Collection(a => a.Sections).Load();

            if (id == null)
            {
                Section section = new Section();
                model.ToSection(ref section, await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent), autor);

                await _oak.Sections.AddAsync(section);
                _oak.SaveChanges();
            }
            else
            {
                Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
                if (!SectionEditedModel.HaveSection(autor, section))
                {
                    return RedirectToAction("Autor", "Autors", new { autor.ID });
                }
                model.ToSection(ref section, await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent), autor);

                _oak.SaveChanges();
            }

            return RedirectToAction("Autor", "Autors", new { autor.ID });
        }

        public async Task<IActionResult> Drop(long? id)
        {
            if (id == null) { return RedirectToAction("News", "Articles"); }

            Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                .Include(a => a.Sections)
                .FirstOrDefaultAsync();

            Section section = await _oak.Sections.Where(s => s.ID == id)
                .Include(s => s.Children)
                .FirstOrDefaultAsync();

            if (!SectionEditedModel.HaveSection(autor, section)) { return RedirectToAction("Autor", "Autors", new { autor.ID }); }

            Section[] sections;
            List<Section> children = section.Children.ToList();
            while (children.Count != 0)
            {
                sections = children.ToArray();
                children.Clear();

                for (int i = 0; i < sections.Length; i++)
                {
                    children.AddRange(_oak.Sections.Where(s => s.ID == sections[i].ID)
                        .Include(s => s.Children)
                        .FirstOrDefault()
                        .Children);
                }

                _oak.Sections.RemoveRange(sections);
            }
            _oak.Sections.Remove(section);
            _oak.SaveChanges();

            return RedirectToAction("Autor", "Autors", new { autor.ID });
        }
    }
}