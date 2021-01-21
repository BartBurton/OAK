using System;
using System.Collections.Generic;

#nullable disable

namespace OAK
{
    public partial class Comment
    {
        public Comment()
        {
            InverseIdparentNavigation = new HashSet<Comment>();
        }

        public long Id { get; set; }
        public string Text { get; set; }
        public long Idautor { get; set; }
        public long Idarticle { get; set; }
        public long? Idparent { get; set; }
        public DateTime Date { get; set; }

        public virtual Article IdarticleNavigation { get; set; }
        public virtual Autor IdautorNavigation { get; set; }
        public virtual Comment IdparentNavigation { get; set; }
        public virtual ICollection<Comment> InverseIdparentNavigation { get; set; }
    }
}
