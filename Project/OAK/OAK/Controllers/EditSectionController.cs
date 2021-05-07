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
            SectionEditedModel model = new SectionEditedModel();

            if (id != null)
            {
                Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
                if (autor is null) return RedirectToAction("All", "Articles");

                Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
                if (section is null) return RedirectToAction("Error", "Articles");

                if (section.AutorID != autor.ID) return RedirectToAction("All", "Articles");


                await _oak.Entry(section).Reference(s => s.Parent).LoadAsync();
                ViewBag.ParentName = (section.Parent is null) ? "..." : section.Parent.Name;
                model.FromSection(section);
            }
            else
            {
                ViewBag.ParentName = "...";
            }

            ViewBag.Source = -1;
            ViewBag.Title = "Работа над ветвью";
            return View(model);
        }

        public async Task<IActionResult> GetSections(long? id, bool requered)
        {
            List<Section> query = await _oak.Sections.ToListAsync();
            if (id != null)
            {
                var section = query.First(s => s.ID == id);
                query.Remove(section);
                if (section.Children != null)
                {
                    List<Section> children = section.Children.ToList();
                    while (children.Count != 0)
                    {
                        if (children[0].Children != null)
                            children.AddRange(children[0].Children);

                        query.Remove(children[0]);
                        children.RemoveAt(0);
                    }
                }
            }
            List<(long?, string)> sections = query.Select(q => ((long?)q.ID, q.Name)).ToList();
            if (!requered)
            {
                sections.Insert(0, (null, "..."));
            }

            ViewBag.ID = id;
            ViewBag.Requered = requered;
            return PartialView("_AllSectionsPartial", sections);
        }

        public async Task<IActionResult> SearchSection(long? id, bool requered, string searched)
        {
            List<Section> query = await _oak.Sections.ToListAsync();
            if (id != null)
            {
                var section = query.First(s => s.ID == id);
                query.Remove(section);
                if (section != null)
                {
                    List<Section> children = section.Children.ToList();
                    while (children.Count != 0)
                    {
                        if (children[0].Children != null)
                            children.AddRange(children[0].Children);

                        query.Remove(children[0]);
                        children.RemoveAt(0);
                    }
                }
            }
            if (string.IsNullOrEmpty(searched))
                searched = "";

            List<(long?, string)> sections = query
                .Where(q => q.Name.ToLower().Contains(searched.ToLower()))
                .Select(q => ((long?)q.ID, q.Name))
                .ToList();

            if (!requered)
            {
                sections.Insert(0, (null, "..."));
            }
            return PartialView("_SearchedSections", sections);
        }


        [HttpPost]
        public async Task<IActionResult> EditCreate(long? id, int source, SectionEditedModel model)
        {
            ViewBag.Source = source;

            if (!model.IsUnique(await _oak.Sections.ToListAsync()))
            {
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Данная ветвь уже существует! Измените предка или название!");

                Section selected = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent);
                ViewBag.ParentName = (selected is null) ? "..." : selected.Name;

                ViewBag.Title = "Работа над ветвью";
                return View(model);
            }
            if (!model.IsCorrect(await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent)))
            {
                ModelState.AddModelError("Parent", "");
                ModelState.AddModelError("Name", "Родительская и дочерняя ветви не могут совпадать!");

                Section selected = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent);
                ViewBag.ParentName = (selected is null) ? "..." : selected.Name;

                ViewBag.Title = "Работа над ветвью";
                return View(model);
            }

            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            if (autor is null) return RedirectToAction("All", "Articles");

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
                if (section.AutorID != autor.ID) return RedirectToAction("All", "Articles");

                model.ToSection(ref section, await _oak.Sections.FirstOrDefaultAsync(s => s.ID == model.Parent), autor);

                _oak.SaveChanges();
            }

            //////////////////////
            return RedirectToAction("ToSource", "Return", new { source });
        }

        public async Task<IActionResult> Drop(long? id, int source)
        {
            Autor autor = await _oak.Autors.FirstOrDefaultAsync(a => a.Email == User.Identity.Name);
            if (autor is null) return RedirectToAction("All", "Articles");

            Section section = await _oak.Sections.FirstOrDefaultAsync(s => s.ID == id);
            if (section is null) return RedirectToAction("Error", "Articles");

            if (section.AutorID != autor.ID) return RedirectToAction("All", "Articles");


            await _oak.Entry(section).Collection(s => s.Children).LoadAsync();
            List<Section> children = section.Children.ToList();
            if(children != null)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    await _oak.Entry(children[i]).Collection(c => c.Children).LoadAsync();
                    if(children[i].Children != null)
                    {
                        children.AddRange(children[i].Children);
                    }
                }
            }
            _oak.Sections.RemoveRange(children);
            _oak.Sections.Remove(section);
            _oak.SaveChanges();


            //////////////////////
            return RedirectToAction("ToSource", "Return", new { source });
        }
    }
}