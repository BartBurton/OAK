using Microsoft.EntityFrameworkCore.Migrations;

namespace OAK.Migrations
{
    public partial class AddLikedToAutorAndLikesToArticle_MTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "ArticleAutor",
                columns: table => new
                {
                    LikedID = table.Column<long>(type: "bigint", nullable: false),
                    LikesID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAutor", x => new { x.LikedID, x.LikesID });
                    table.ForeignKey(
                        name: "FK_ArticleAutor_Articles_LikedID",
                        column: x => x.LikedID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleAutor_Autors_LikesID",
                        column: x => x.LikesID,
                        principalTable: "Autors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAutor_LikesID",
                table: "ArticleAutor",
                column: "LikesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleAutor");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
