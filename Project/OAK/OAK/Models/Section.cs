using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class Section
    {
        public Section()
        {
            Articles = new HashSet<Article>();
            FavSections = new HashSet<FavSection>();
            InverseIdparentNavigation = new HashSet<Section>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? Idparent { get; set; }
        public long? Idautor { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Section IdparentNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<FavSection> FavSections { get; set; }
        public virtual ICollection<Section> InverseIdparentNavigation { get; set; }
    }
}
