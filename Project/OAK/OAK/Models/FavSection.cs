using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class FavSection
    {
        public long Idautor { get; set; }
        public long Idsection { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Section IdsectionNavigation { get; set; }
    }
}
