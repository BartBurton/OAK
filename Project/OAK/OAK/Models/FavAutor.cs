using System;
using System.Collections.Generic;

#nullable disable

namespace OAK.Models
{
    public partial class FavAutor
    {
        public long Idautororigin { get; set; }
        public long Idautorfavorite { get; set; }

        public virtual Autor IdautorfavoriteNavigation { get; set; }
        public virtual Autor IdautororiginNavigation { get; set; }
    }
}
