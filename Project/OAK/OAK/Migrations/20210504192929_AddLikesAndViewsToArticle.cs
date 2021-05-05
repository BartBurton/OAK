using Microsoft.EntityFrameworkCore.Migrations;

namespace OAK.Migrations
{
    public partial class AddLikesAndViewsToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Articles");
        }
    }
}
