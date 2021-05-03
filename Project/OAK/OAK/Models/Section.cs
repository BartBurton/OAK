using System.Collections.Generic;

#nullable disable

namespace OAK.Models
{
    public class Section
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public long? ParentID { get; set; }
        public long? AutorID { get; set; }

        public Autor Autor { get; set; }
        public Section Parent { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Section> Children { get; set; }
    }
}