using System;
using System.Collections.Generic;

#nullable disable

namespace OAK.Models
{
    public partial class Article
    {
        public Article()
        {
            ArtImages = new HashSet<ArtImage>();
            ArtSubtitles = new HashSet<ArtSubtitle>();
            ArtTexts = new HashSet<ArtText>();
            Comments = new HashSet<Comment>();
            FavArticles = new HashSet<FavArticle>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Idautor { get; set; }
        public long Idsection { get; set; }
        public DateTime Date { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Section IdsectionNavigation { get; set; }
        public virtual ICollection<ArtImage> ArtImages { get; set; }
        public virtual ICollection<ArtSubtitle> ArtSubtitles { get; set; }
        public virtual ICollection<ArtText> ArtTexts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavArticle> FavArticles { get; set; }
    }
}
