﻿using Microsoft.AspNetCore.Mvc;
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
                Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.Id == id);

                Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                    .Include(a => a.Sections)
                    .FirstOrDefaultAsync();

                if (!SectionEditedModel.HaveSection(autor, section)) { return RedirectToAction("Profile", "Profile"); }

                model.FromSection(section);
            } 

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditCreateSection(long? id, SectionEditedModel model)
        {
            ViewData["Sections"] = await _oak.Sections.ToListAsync();
            if (!model.IsUnique(await _oak.Sections.ToListAsync()))
            {
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Данная ветвь уже существует! Измените предка или название!");
                return View(model);
            }
            if (!model.IsCorrect(await _oak.Sections.FirstOrDefaultAsync(s => s.Id == model.Parent)))
            {
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Родительская и дочерняя ветви не могут совпадать!");
                return View(model);
            }

            Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                    .Include(a => a.Sections)
                    .FirstOrDefaultAsync();
            if (id == null)
            {
                Section section = new Section();
                model.ToSection(ref section, await _oak.Sections.FirstOrDefaultAsync(s => s.Id == model.Parent), autor);

                await _oak.Sections.AddAsync(section);
                _oak.SaveChanges();
            }
            else
            {
                Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.Id == id);
                if (!SectionEditedModel.HaveSection(autor, section)) { return RedirectToAction("Profile", "Profile"); }
                model.ToSection(ref section, await _oak.Sections.FirstOrDefaultAsync(s => s.Id == model.Parent), autor);

                _oak.SaveChanges();
            }


            return RedirectToAction("Profile", "Profile");
        }



        public async Task<IActionResult> DropSection(long? id)
        {
            if(id == null) { return RedirectToAction("Profile", "Profile"); }

            Autor autor = await _oak.Autors.Where(a => a.Email == User.Identity.Name)
                .Include(a => a.Sections)
                .FirstOrDefaultAsync();

            Section section = await _oak.Sections.Where(s => s.Id == id)
                .Include(s => s.InverseIdparentNavigation)
                .FirstOrDefaultAsync();

            if (!SectionEditedModel.HaveSection(autor, section)) { return RedirectToAction("Profile", "Profile"); }

            Section[] sections;
            List<Section> children = section.InverseIdparentNavigation.ToList();
            while (children.Count != 0)
            {
                sections = children.ToArray();
                children.Clear();

                for (int i = 0; i < sections.Length; i++)
                {
                    children.AddRange(_oak.Sections.Where(s => s.Id == sections[i].Id)
                        .Include(s => s.InverseIdparentNavigation)
                        .FirstOrDefault()
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
