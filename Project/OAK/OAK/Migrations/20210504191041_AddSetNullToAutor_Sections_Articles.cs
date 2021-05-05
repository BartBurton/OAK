using Microsoft.EntityFrameworkCore.Migrations;

namespace OAK.Migrations
{
    public partial class AddSetNullToAutor_Sections_Articles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Autors_AutorID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Autors_AutorID",
                table: "Sections");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Autor",
                table: "Articles",
                column: "AutorID",
                principalTable: "Autors",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Autor",
                table: "Sections",
                column: "AutorID",
                principalTable: "Autors",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Autor",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Autor",
                table: "Sections");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Autors_AutorID",
                table: "Articles",
                column: "AutorID",
                principalTable: "Autors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Autors_AutorID",
                table: "Sections",
                column: "AutorID",
                principalTable: "Autors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
