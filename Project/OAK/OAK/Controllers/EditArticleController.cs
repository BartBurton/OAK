using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OAK.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace OAK.Controllers
{
    [Authorize]
    public class EditArticleController : Controller
    {
        private readonly OAKContext _oak;

        public EditArticleController(OAKContext oak)
        {
            _oak = oak;
        }
        


        public async Task<IActionResult> EditCreateArticle(long? id)
        {
            ViewData["Sections"] = _oak.Sections.ToList();
            Article model = new Article();

            if(id != null)
            {
                model = await _oak.Articles
                    .Include(a => a.ArtTexts)
                    .Include(a => a.ArtSubtitles)
                    .Include(a => a.ArtImages)
                    .FirstOrDefaultAsync(a => a.Id == id);

                Autor autor = await _oak.Autors
                    .Include(a => a.Articles)
                    .FirstOrDefaultAsync(a => a.Email == User.Identity.Name);

                if (!autor.Articles.Contains(model)) { return RedirectToAction("Profile", "Profile"); }
            }

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> EditCreateArticle(long? id, Article model)
        {
            (ICollection<ArtText> text, ICollection<ArtSubtitle> sub, ICollection<ArtImage> img) content = 
                GetContent(HttpContext.Request.Form);

            model.ArtTexts = content.text;
            model.ArtSubtitles = content.sub;
            model.ArtImages = content.img;

            if(IsValid(content))
            {
                ViewData["Sections"] = await _oak.Sections.ToListAsync();
                ModelState.AddModelError("Date", "Хотя бы одно поле контента должно быть заполнено!");
                return View(model);
            }

            return RedirectToAction("Profile", "Profile");
        }

        private (ICollection<ArtText>, ICollection<ArtSubtitle>, ICollection<ArtImage>) 
            GetContent(IFormCollection request)
        {
            (ICollection<ArtText> text, ICollection<ArtSubtitle> sub, ICollection<ArtImage> img) content;

            List<ArtText> valuesText = new List<ArtText>();
            List<ArtSubtitle> valuesSub = new List<ArtSubtitle>();
            List<ArtImage> valuesImg = new List<ArtImage>();

            foreach (var item in request)
            {
                if(item.Key[0..4] == "text" && item.Value != "")
                {
                    valuesText.Add(new ArtText() 
                    { 
                        Number = Convert.ToInt16(item.Key[4..]),
                        Idtext = Guid.NewGuid(),
                        Text = Encoding.UTF8.GetBytes(item.Value)
                    });
                }
                else if(item.Key[0..3] == "sub" && item.Value != "")
                {
                    valuesSub.Add(new ArtSubtitle()
                    {
                        Number = Convert.ToInt16(item.Key[3..]),
                        Idsubtitle = Guid.NewGuid(),
                        Subtitle = Encoding.UTF8.GetBytes(item.Value)
                    });
                }
            }
            foreach (var item in request.Files)
            {
                valuesImg.Add(new ArtImage() 
                { 
                    Number = Convert.ToInt16(item.Name[3..]),
                    Idimage = Guid.NewGuid(),
                });
                using (BinaryReader br = new BinaryReader(item.OpenReadStream()))
                {
                    valuesImg.Last().Image = br.ReadBytes((int)br.BaseStream.Length);
                }
            }

            content = (valuesText, valuesSub, valuesImg);
            return content;
        }

        private bool IsValid(
            (ICollection<ArtText> text, ICollection<ArtSubtitle> sub, ICollection<ArtImage> img) content)
        {
            if (content.text.Count != 0) { return true; }
            if (content.sub.Count != 0) { return true; }
            if (content.img.Count != 0) { return true; }
            return false;
        }


        public IActionResult DropArticle(long? id)
        {
            return View();
        }
    }
}
