using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        public virtual DbSet<ArtImage> ArtImages { get; set; }
        public virtual DbSet<ArtSubtitle> ArtSubtitles { get; set; }
        public virtual DbSet<ArtText> ArtTexts { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FavArticle> FavArticles { get; set; }
        public virtual DbSet<FavAutor> FavAutors { get; set; }
        public virtual DbSet<FavSection> FavSections { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<ArtImage>(entity =>
            {
                entity.HasKey(e => new { e.Idarticle, e.Number })
                    .HasName("PK__ART_IMAG__2CA2BCC3E9F2402D");

                entity.ToTable("ART_IMAGES");

                entity.HasIndex(e => e.Idimage, "UQ__ART_IMAG__D85382DAEBE9295E")
                    .IsUnique();

                entity.Property(e => e.Idarticle).HasColumnName("IDARTICLE");

                entity.Property(e => e.Number).HasColumnName("NUMBER");

                entity.Property(e => e.Idimage).HasColumnName("IDIMAGE");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("IMAGE");

                entity.HasOne(d => d.IdarticleNavigation)
                    .WithMany(p => p.ArtImages)
                    .HasForeignKey(d => d.Idarticle)
                    .HasConstraintName("FK_ART_IMAGES_TO_ARTICLE");
            });

            modelBuilder.Entity<ArtSubtitle>(entity =>
            {
                entity.HasKey(e => new { e.Idarticle, e.Number })
                    .HasName("PK__ART_SUBT__2CA2BCC34EC62D80");

                entity.ToTable("ART_SUBTITLES");

                entity.HasIndex(e => e.Idsubtitle, "UQ__ART_SUBT__D2F7C979136CD517")
                    .IsUnique();

                entity.Property(e => e.Idarticle).HasColumnName("IDARTICLE");

                entity.Property(e => e.Number).HasColumnName("NUMBER");

                entity.Property(e => e.Idsubtitle).HasColumnName("IDSUBTITLE");

                entity.Property(e => e.Subtitle)
                    .IsRequired()
                    .HasColumnName("SUBTITLE");

                entity.HasOne(d => d.IdarticleNavigation)
                    .WithMany(p => p.ArtSubtitles)
                    .HasForeignKey(d => d.Idarticle)
                    .HasConstraintName("FK_ART_SUBTITLES_TO_ARTICLE");
            });

            modelBuilder.Entity<ArtText>(entity =>
            {
                entity.HasKey(e => new { e.Idarticle, e.Number })
                    .HasName("PK__ART_TEXT__2CA2BCC3421BA1CB");

                entity.ToTable("ART_TEXTS");

                entity.HasIndex(e => e.Idtext, "UQ__ART_TEXT__98C742825A1C50E4")
                    .IsUnique();

                entity.Property(e => e.Idarticle).HasColumnName("IDARTICLE");

                entity.Property(e => e.Number).HasColumnName("NUMBER");

                entity.Property(e => e.Idtext).HasColumnName("IDTEXT");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("TEXT");

                entity.HasOne(d => d.IdarticleNavigation)
                    .WithMany(p => p.ArtTexts)
                    .HasForeignKey(d => d.Idarticle)
                    .HasConstraintName("FK_ART_TEXT_TO_ARTICLE");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("ARTICLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Idautor).HasColumnName("IDAUTOR");

                entity.Property(e => e.Idsection).HasColumnName("IDSECTION");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ARTICLES_TO_AUTOR");

                entity.HasOne(d => d.IdsectionNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Idsection)
                    .HasConstraintName("FK_ARTICLES_TO_SECTIONS");
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("AUTORS");

                entity.HasIndex(e => e.Email, "UQ__AUTORS__161CF7242BA1BD92")
                    .IsUnique();

                entity.HasIndex(e => e.Idavatar, "UQ__AUTORS__86F9C663321D88B5")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "UQ__AUTORS__93DCC1BE599C6D8C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Avatar)
                    .IsRequired()
                    .HasColumnName("AVATAR");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Idavatar).HasColumnName("IDAVATAR");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Status)
                    .HasMaxLength(512)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("('No status')");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Idarticle).HasColumnName("IDARTICLE");

                entity.Property(e => e.Idautor).HasColumnName("IDAUTOR");

                entity.Property(e => e.Idparent).HasColumnName("IDPARENT");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .HasColumnName("TEXT");

                entity.HasOne(d => d.IdarticleNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Idarticle)
                    .HasConstraintName("FK_COMMENTS_TO_ARTICLE");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Idautor)
                    .HasConstraintName("FK_COMMENTS_TO_AUTOR");

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("FK_COMMENTS_TO_COMMENT");
            });

            modelBuilder.Entity<FavArticle>(entity =>
            {
                entity.HasKey(e => new { e.Idautor, e.Idarticle })
                    .HasName("PK__FAV_ARTI__2F2950A426EA767F");

                entity.ToTable("FAV_ARTICLES");

                entity.Property(e => e.Idautor).HasColumnName("IDAUTOR");

                entity.Property(e => e.Idarticle).HasColumnName("IDARTICLE");

                entity.HasOne(d => d.IdarticleNavigation)
                    .WithMany(p => p.FavArticles)
                    .HasForeignKey(d => d.Idarticle)
                    .HasConstraintName("FK__FAV_ARTIC__IDART__5224328E");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.FavArticles)
                    .HasForeignKey(d => d.Idautor)
                    .HasConstraintName("FK_FAV_ARTICLES_TO_AUTORS");
            });

            modelBuilder.Entity<FavAutor>(entity =>
            {
                entity.HasKey(e => new { e.Idautororigin, e.Idautorfavorite })
                    .HasName("PK__FAV_AUTO__06B014F80E14F697");

                entity.ToTable("FAV_AUTORS");

                entity.Property(e => e.Idautororigin).HasColumnName("IDAUTORORIGIN");

                entity.Property(e => e.Idautorfavorite).HasColumnName("IDAUTORFAVORITE");

                entity.HasOne(d => d.IdautorfavoriteNavigation)
                    .WithMany(p => p.FavAutorIdautorfavoriteNavigations)
                    .HasForeignKey(d => d.Idautorfavorite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAV_AUTOR__IDAUT__4E53A1AA");

                entity.HasOne(d => d.IdautororiginNavigation)
                    .WithMany(p => p.FavAutorIdautororiginNavigations)
                    .HasForeignKey(d => d.Idautororigin)
                    .HasConstraintName("FK_FAV_AUTORS_TO_AUTORS");
            });

            modelBuilder.Entity<FavSection>(entity =>
            {
                entity.HasKey(e => new { e.Idautor, e.Idsection })
                    .HasName("PK__FAV_SECT__8A717D0B9CC6ED5C");

                entity.ToTable("FAV_SECTIONS");

                entity.Property(e => e.Idautor).HasColumnName("IDAUTOR");

                entity.Property(e => e.Idsection).HasColumnName("IDSECTION");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.FavSections)
                    .HasForeignKey(d => d.Idautor)
                    .HasConstraintName("FK_FAV_SECTIONS_TO_AUTORS");

                entity.HasOne(d => d.IdsectionNavigation)
                    .WithMany(p => p.FavSections)
                    .HasForeignKey(d => d.Idsection)
                    .HasConstraintName("FK__FAV_SECTI__IDSEC__55F4C372");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("SECTIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idautor).HasColumnName("IDAUTOR");

                entity.Property(e => e.Idparent).HasColumnName("IDPARENT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_SECTIONS_TO_AUTOR");

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("FK_SECTIONS_TO_SECTION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
