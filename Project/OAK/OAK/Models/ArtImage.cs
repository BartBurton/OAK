using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class ArtImage
    {
        public long Idarticle { get; set; }
        public short Number { get; set; }
        public Guid Idimage { get; set; }
        public byte[] Image { get; set; }

        public virtual Article IdarticleNavigation { get; set; }
    }
}
