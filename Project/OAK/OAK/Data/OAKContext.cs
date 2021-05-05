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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Section>()
				.HasOne(s => s.Autor)
				.WithMany(a => a.Sections)
				.HasForeignKey(s => s.AutorID)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Sections_Autor");

			modelBuilder.Entity<Article>()
				.HasOne(a => a.Autor)
				.WithMany(a => a.Articles)
				.HasForeignKey(a => a.AutorID)
				.OnDelete(DeleteBehavior.SetNull)
				.HasConstraintName("FK_Articles_Autor");
		}
	}
}