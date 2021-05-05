﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OAK;

namespace OAK.Migrations
{
    [DbContext(typeof(OAKContext))]
    partial class OAKContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ArticleAutor", b =>
                {
                    b.Property<long>("LikedID")
                        .HasColumnType("bigint");

                    b.Property<long>("LikesID")
                        .HasColumnType("bigint");

                    b.HasKey("LikedID", "LikesID");

                    b.HasIndex("LikesID");

                    b.ToTable("ArticleAutor");
                });

            modelBuilder.Entity("OAK.Models.ArtImage", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ArticleID")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("ArticleID");

                    b.ToTable("ArtImages");
                });

            modelBuilder.Entity("OAK.Models.ArtSubtitle", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ArticleID")
                        .HasColumnType("bigint");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.Property<byte[]>("Subtitle")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("ArticleID");

                    b.ToTable("ArtSubtitles");
                });

            modelBuilder.Entity("OAK.Models.ArtText", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ArticleID")
                        .HasColumnType("bigint");

                    b.Property<short>("Number")
                        .HasColumnType("smallint");

                    b.Property<byte[]>("Text")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("ArticleID");

                    b.ToTable("ArtTexts");
                });

            modelBuilder.Entity("OAK.Models.Article", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AutorID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SectionID")
                        .HasColumnType("bigint");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AutorID");

                    b.HasIndex("SectionID");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("OAK.Models.Autor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("OAK.Models.Section", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AutorID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("AutorID");

                    b.HasIndex("ParentID");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ArticleAutor", b =>
                {
                    b.HasOne("OAK.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("LikedID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OAK.Models.Autor", null)
                        .WithMany()
                        .HasForeignKey("LikesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OAK.Models.ArtImage", b =>
                {
                    b.HasOne("OAK.Models.Article", "Article")
                        .WithMany("ArtImages")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("OAK.Models.ArtSubtitle", b =>
                {
                    b.HasOne("OAK.Models.Article", "Article")
                        .WithMany("ArtSubtitles")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("OAK.Models.ArtText", b =>
                {
                    b.HasOne("OAK.Models.Article", "Article")
                        .WithMany("ArtTexts")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("OAK.Models.Article", b =>
                {
                    b.HasOne("OAK.Models.Autor", "Autor")
                        .WithMany("Articles")
                        .HasForeignKey("AutorID")
                        .HasConstraintName("FK_Articles_Autor")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OAK.Models.Section", "Section")
                        .WithMany("Articles")
                        .HasForeignKey("SectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("OAK.Models.Section", b =>
                {
                    b.HasOne("OAK.Models.Autor", "Autor")
                        .WithMany("Sections")
                        .HasForeignKey("AutorID")
                        .HasConstraintName("FK_Sections_Autor")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OAK.Models.Section", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentID");

                    b.Navigation("Autor");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("OAK.Models.Article", b =>
                {
                    b.Navigation("ArtImages");

                    b.Navigation("ArtSubtitles");

                    b.Navigation("ArtTexts");
                });

            modelBuilder.Entity("OAK.Models.Autor", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("OAK.Models.Section", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
