using System.Collections.Generic;


namespace OAK.Models
{
    public class Autor
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public byte[] Avatar { get; set; }
        public string? Code { get; set; }

        public ICollection<Article> Liked { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}