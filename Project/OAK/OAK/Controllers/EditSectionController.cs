using Microsoft.AspNetCore.Mvc;
using System;
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
    public class EditSectionController : Controller
    {
        private readonly OAKContext _oak;

        public EditSectionController(OAKContext oak)
        {
            _oak = oak;
        }

        [HttpGet]
        public async Task<IActionResult> EditCreateSection(long? id)
        {
            ViewData["Sections"] = await _oak.Sections.ToListAsync();

            SectionEditedModel model = new SectionEditedModel();
            if (id != null)
            {
                Section section = await _oak.Sections
                    .Include(s => s.IdparentNavigation)
                    .FirstOrDefaultAsync(s => s.Id == id);

                Autor autor = await _oak.Autors
                    .Include(a => a.Sections)
                    .FirstOrDefaultAsync(a => a.Email == User.Identity.Name);

                if (!autor.Sections.Contains(section))
                {
                    return RedirectToAction("Profile", "Profile");
                }

                model.Id = section.Id;
                model.Name = section.Name;
                model.Parent = section.IdparentNavigation?.Id;
            } 

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditCreateSection(long? id, SectionEditedModel model)
        {
            Section sameSection = await _oak.Sections
                .FirstOrDefaultAsync(s => s.Name == model.Name && s.Idparent == model.Parent);
            if (sameSection != null)
            {
                ViewData["Sections"] = await _oak.Sections.ToListAsync();
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Данная ветвь уже существует! Измените предка или название!");
                return View(model);
            }


            Autor autor = await _oak.Autors
                    .Include(a => a.Sections)
                    .FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            if (id == null)
            {
                Section section = new Section()
                {
                    Name = model.Name,
                    IdparentNavigation = await _oak.Sections.FirstOrDefaultAsync(s => s.Id == model.Parent),
                    IdautorNavigation = autor
                };
                await _oak.Sections.AddAsync(section);
                _oak.SaveChanges();
            }
            else
            {
                Section section = await _oak.Sections
                    .Include(s => s.IdparentNavigation)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (!autor.Sections.Contains(section))
                {
                    return RedirectToAction("Profile", "Profile");
                }

                section.Name = model.Name;
                section.IdparentNavigation = await _oak.Sections.FirstOrDefaultAsync(s => s.Id == model.Parent);
                _oak.SaveChanges();
            }


            return RedirectToAction("Profile", "Profile");
        }



        public async Task<IActionResult> DropSection(long? id)
        {
            if(id == null) { return RedirectToAction("Profile", "Profile"); }

            Autor autor = await _oak.Autors
                .Include(a => a.Sections)
                .FirstOrDefaultAsync(a => a.Email == User.Identity.Name);

            Section section = await _oak.Sections
                .Include(s => s.InverseIdparentNavigation)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (!autor.Sections.Contains(section)) { return RedirectToAction("Profile", "Profile"); }

            Section[] sections;
            List<Section> children = section.InverseIdparentNavigation.ToList();
            while (children.Count != 0)
            {
                sections = children.ToArray();
                children.Clear();

                for (int i = 0; i < sections.Length; i++)
                {
                    children.AddRange(_oak.Sections
                        .Include(s => s.InverseIdparentNavigation)
                        .FirstOrDefault(s => s.Id == sections[i].Id)
                        .InverseIdparentNavigation);
                }

                _oak.Sections.RemoveRange(sections);
            }
            _oak.Sections.Remove(section);
            _oak.SaveChanges();

            return RedirectToAction("Profile", "Profile");
        }
    }
}
