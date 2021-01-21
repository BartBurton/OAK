using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class Autor
    {
        public Autor()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            FavArticles = new HashSet<FavArticle>();
            FavAutorIdautorfavoriteNavigations = new HashSet<FavAutor>();
            FavAutorIdautororiginNavigations = new HashSet<FavAutor>();
            FavSections = new HashSet<FavSection>();
            Sections = new HashSet<Section>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public Guid Idavatar { get; set; }
        public byte[] Avatar { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavArticle> FavArticles { get; set; }
        public virtual ICollection<FavAutor> FavAutorIdautorfavoriteNavigations { get; set; }
        public virtual ICollection<FavAutor> FavAutorIdautororiginNavigations { get; set; }
        public virtual ICollection<FavSection> FavSections { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
