using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class ArtSubtitle
    {
        public long Idarticle { get; set; }
        public short Number { get; set; }
        public Guid Idsubtitle { get; set; }
        public byte[] Subtitle { get; set; }

        public virtual Article IdarticleNavigation { get; set; }
    }
}
