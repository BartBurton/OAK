using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace OAK.Models.Edited
{
    public class ArticleEditedModel
    {
        public long? Id { get; set; } = null;

        [Required]
        [MaxLength(32, ErrorMessage = "Не больше 32 символов!")]
        public string Name { get; set; }

        [Required]
        public long Section { get; set; }

        public DateTime DateTime { get; set; }

        private List<(string Type, short Number, byte[] Data)> _content { get; set; } =
            new List<(string Type, short Number, byte[] Data)>();

        public List<(string Type, short Number, byte[] Data)> Content
        {
            get => _content.OrderBy(e => e.Number).ToList();
            set => _content = value;
        }

        public ArticleEditedModel()
        {
            DateTime = System.DateTime.Now;
        }

        public void FromArticle(Article article)
        {
            Id = article.ID;
            Name = article.Name;
            Section = article.SectionID;

            _content.AddRange(from t in article.ArtTexts select ("text", t.Number, t.Text));
            _content.AddRange(from s in article.ArtSubtitles select ("sub", s.Number, s.Subtitle));
            _content.AddRange(from i in article.ArtImages select ("img", i.Number, i.Image));
        }

        public void ToArticle(Article article, Autor autor, Section section)
        {
            article.Name = Name;
            article.Date = DateTime;
            article.Autor = autor;
            article.SectionID = Section;
            article.Section = section;

            article.ArtTexts = (from t in Content
                                where t.Type == "text"
                                select new ArtText()
                                {
                                    Article = article,
                                    Number = t.Number,
                                    Text = t.Data
                                }).ToList();

            article.ArtSubtitles = (from t in Content
                                    where t.Type == "sub"
                                    select new ArtSubtitle()
                                    {
                                        Article = article,
                                        Number = t.Number,
                                        Subtitle = t.Data
                                    }).ToList();

            article.ArtImages = (from t in Content
                                 where t.Type == "img"
                                 select new ArtImage()
                                 {
                                     Article = article,
                                     Number = t.Number,
                                     Image = t.Data
                                 }).ToList();
        }

        private void addContent(string type, short number, byte[] data)
        {
            _content.RemoveAll(e => e.Type == type && e.Number == number);

            if (data.Length != 0)
            {
                _content.Add((type, number, data));
            }
        }

        private void delExcessContent(IFormCollection request)
        {
            var content = _content.Select(e => (e.Type, e.Number));
            IEnumerable<(string, short)> req;

            void delete()
            {
                var deleted = req.Except(content);
                foreach (var item in deleted)
                {
                    _content.RemoveAll(e => e.Type == item.Item1 && e.Number == item.Item2);
                }
            }

            req = request.Where(e => e.Key[0..4] == "text").Select(e => (e.Key[0..4], Convert.ToInt16(e.Key[4..])));
            delete();
            req = request.Where(e => e.Key[0..3] == "sub").Select(e => (e.Key[0..3], Convert.ToInt16(e.Key[3..])));
            delete();
            req = request.Where(e => e.Key[0..3] == "img").Select(e => (e.Key[0..3], Convert.ToInt16(e.Key[3..])));
            delete();
        }

        public void FromRequest(IFormCollection request)
        {
            string type;
            short number;
            byte[] data;

            foreach (var item in request)
            {
                if (item.Key[0..4] == "text")
                {
                    type = item.Key[0..4];
                    number = Convert.ToInt16(item.Key[4..]);
                    data = Encoding.UTF8.GetBytes(item.Value);
                    addContent(type, number, data);
                }
                else if (item.Key[0..3] == "sub")
                {
                    type = item.Key[0..3];
                    number = Convert.ToInt16(item.Key[3..]);
                    data = Encoding.UTF8.GetBytes(item.Value);
                    addContent(type, number, data);
                }
                else if (item.Key[0..3] == "img")
                {
                    type = item.Key[0..3];
                    number = Convert.ToInt16(item.Key[3..]);
                    data = Convert.FromBase64String(item.Value);
                    addContent(type, number, data);
                }
            }
            foreach (var item in request.Files)
            {
                if (item.Name[0..3] == "img")
                {
                    type = item.Name[0..3];
                    number = Convert.ToInt16(item.Name[3..]);
                    using (BinaryReader br = new BinaryReader(item.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)br.BaseStream.Length);
                    }
                    addContent(type, number, data);
                }
            }
            delExcessContent(request);
        }

        static public bool HaveArticle(Autor autor, Article article)
            => autor.Articles.Contains(article);

        public bool IsCorrect
            => _content.Any(e => e.Type == "text") && _content.Any(e => e.Type == "img");
    }
}