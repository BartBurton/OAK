using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class ArtText
    {
        public long Idarticle { get; set; }
        public short Number { get; set; }
        public Guid Idtext { get; set; }
        public byte[] Text { get; set; }

        public virtual Article IdarticleNavigation { get; set; }
    }
}
