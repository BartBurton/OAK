using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class FavArticle
    {
        public long Idautor { get; set; }
        public long Idarticle { get; set; }

        public virtual Article IdarticleNavigation { get; set; }
        public virtual Autor IdautorNavigation { get; set; }
    }
}
