using Microsoft.EntityFrameworkCore;
using OAK.Models;

#nullable disable

namespace OAK
{
    public partial class OAKContext : DbContext
    {
        public OAKContext(DbContextOptions<OAKContext> options)
            : base(options)
        {
        }

        public DbSet<ArtImage> ArtImages { get; set; }
        public DbSet<ArtSubtitle> ArtSubtitles { get; set; }
        public DbSet<ArtText> ArtTexts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}