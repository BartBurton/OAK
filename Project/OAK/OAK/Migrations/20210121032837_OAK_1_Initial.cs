using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OAK.Migrations
{
    public partial class OAK_1_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTORS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true, defaultValueSql: "('No status')"),
                    IDAVATAR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AVATAR = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTORS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAV_AUTORS",
                columns: table => new
                {
                    IDAUTORORIGIN = table.Column<long>(type: "bigint", nullable: false),
                    IDAUTORFAVORITE = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FAV_AUTO__06B014F80E14F697", x => new { x.IDAUTORORIGIN, x.IDAUTORFAVORITE });
                    table.ForeignKey(
                        name: "FK__FAV_AUTOR__IDAUT__4E53A1AA",
                        column: x => x.IDAUTORFAVORITE,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAV_AUTORS_TO_AUTORS",
                        column: x => x.IDAUTORORIGIN,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SECTIONS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IDPARENT = table.Column<long>(type: "bigint", nullable: true),
                    IDAUTOR = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECTIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SECTIONS_TO_AUTOR",
                        column: x => x.IDAUTOR,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SECTIONS_TO_SECTION",
                        column: x => x.IDPARENT,
                        principalTable: "SECTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ARTICLES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IDAUTOR = table.Column<long>(type: "bigint", nullable: true),
                    IDSECTION = table.Column<long>(type: "bigint", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTICLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ARTICLES_TO_AUTOR",
                        column: x => x.IDAUTOR,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ARTICLES_TO_SECTIONS",
                        column: x => x.IDSECTION,
                        principalTable: "SECTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAV_SECTIONS",
                columns: table => new
                {
                    IDAUTOR = table.Column<long>(type: "bigint", nullable: false),
                    IDSECTION = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FAV_SECT__8A717D0B9CC6ED5C", x => new { x.IDAUTOR, x.IDSECTION });
                    table.ForeignKey(
                        name: "FK__FAV_SECTI__IDSEC__55F4C372",
                        column: x => x.IDSECTION,
                        principalTable: "SECTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAV_SECTIONS_TO_AUTORS",
                        column: x => x.IDAUTOR,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ART_IMAGES",
                columns: table => new
                {
                    IDARTICLE = table.Column<long>(type: "bigint", nullable: false),
                    NUMBER = table.Column<short>(type: "smallint", nullable: false),
                    IDIMAGE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ART_IMAG__2CA2BCC3E9F2402D", x => new { x.IDARTICLE, x.NUMBER });
                    table.ForeignKey(
                        name: "FK_ART_IMAGES_TO_ARTICLE",
                        column: x => x.IDARTICLE,
                        principalTable: "ARTICLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ART_SUBTITLES",
                columns: table => new
                {
                    IDARTICLE = table.Column<long>(type: "bigint", nullable: false),
                    NUMBER = table.Column<short>(type: "smallint", nullable: false),
                    IDSUBTITLE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SUBTITLE = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ART_SUBT__2CA2BCC34EC62D80", x => new { x.IDARTICLE, x.NUMBER });
                    table.ForeignKey(
                        name: "FK_ART_SUBTITLES_TO_ARTICLE",
                        column: x => x.IDARTICLE,
                        principalTable: "ARTICLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ART_TEXTS",
                columns: table => new
                {
                    IDARTICLE = table.Column<long>(type: "bigint", nullable: false),
                    NUMBER = table.Column<short>(type: "smallint", nullable: false),
                    IDTEXT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TEXT = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ART_TEXT__2CA2BCC3421BA1CB", x => new { x.IDARTICLE, x.NUMBER });
                    table.ForeignKey(
                        name: "FK_ART_TEXT_TO_ARTICLE",
                        column: x => x.IDARTICLE,
                        principalTable: "ARTICLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEXT = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IDAUTOR = table.Column<long>(type: "bigint", nullable: false),
                    IDARTICLE = table.Column<long>(type: "bigint", nullable: false),
                    IDPARENT = table.Column<long>(type: "bigint", nullable: true),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMMENTS_TO_ARTICLE",
                        column: x => x.IDARTICLE,
                        principalTable: "ARTICLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMMENTS_TO_AUTOR",
                        column: x => x.IDAUTOR,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMMENTS_TO_COMMENT",
                        column: x => x.IDPARENT,
                        principalTable: "COMMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAV_ARTICLES",
                columns: table => new
                {
                    IDAUTOR = table.Column<long>(type: "bigint", nullable: false),
                    IDARTICLE = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FAV_ARTI__2F2950A426EA767F", x => new { x.IDAUTOR, x.IDARTICLE });
                    table.ForeignKey(
                        name: "FK__FAV_ARTIC__IDART__5224328E",
                        column: x => x.IDARTICLE,
                        principalTable: "ARTICLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAV_ARTICLES_TO_AUTORS",
                        column: x => x.IDAUTOR,
                        principalTable: "AUTORS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__ART_IMAG__D85382DAEBE9295E",
                table: "ART_IMAGES",
                column: "IDIMAGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ART_SUBT__D2F7C979136CD517",
                table: "ART_SUBTITLES",
                column: "IDSUBTITLE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__ART_TEXT__98C742825A1C50E4",
                table: "ART_TEXTS",
                column: "IDTEXT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLES_IDAUTOR",
                table: "ARTICLES",
                column: "IDAUTOR");

            migrationBuilder.CreateIndex(
                name: "IX_ARTICLES_IDSECTION",
                table: "ARTICLES",
                column: "IDSECTION");

            migrationBuilder.CreateIndex(
                name: "UQ__AUTORS__161CF7242BA1BD92",
                table: "AUTORS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__AUTORS__86F9C663321D88B5",
                table: "AUTORS",
                column: "IDAVATAR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__AUTORS__93DCC1BE599C6D8C",
                table: "AUTORS",
                column: "PASSWORD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_IDARTICLE",
                table: "COMMENTS",
                column: "IDARTICLE");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_IDAUTOR",
                table: "COMMENTS",
                column: "IDAUTOR");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_IDPARENT",
                table: "COMMENTS",
                column: "IDPARENT");

            migrationBuilder.CreateIndex(
                name: "IX_FAV_ARTICLES_IDARTICLE",
                table: "FAV_ARTICLES",
                column: "IDARTICLE");

            migrationBuilder.CreateIndex(
                name: "IX_FAV_AUTORS_IDAUTORFAVORITE",
                table: "FAV_AUTORS",
                column: "IDAUTORFAVORITE");

            migrationBuilder.CreateIndex(
                name: "IX_FAV_SECTIONS_IDSECTION",
                table: "FAV_SECTIONS",
                column: "IDSECTION");

            migrationBuilder.CreateIndex(
                name: "IX_SECTIONS_IDAUTOR",
                table: "SECTIONS",
                column: "IDAUTOR");

            migrationBuilder.CreateIndex(
                name: "IX_SECTIONS_IDPARENT",
                table: "SECTIONS",
                column: "IDPARENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ART_IMAGES");

            migrationBuilder.DropTable(
                name: "ART_SUBTITLES");

            migrationBuilder.DropTable(
                name: "ART_TEXTS");

            migrationBuilder.DropTable(
                name: "COMMENTS");

            migrationBuilder.DropTable(
                name: "FAV_ARTICLES");

            migrationBuilder.DropTable(
                name: "FAV_AUTORS");

            migrationBuilder.DropTable(
                name: "FAV_SECTIONS");

            migrationBuilder.DropTable(
                name: "ARTICLES");

            migrationBuilder.DropTable(
                name: "SECTIONS");

            migrationBuilder.DropTable(
                name: "AUTORS");
        }
    }
}
