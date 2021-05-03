using Microsoft.EntityFrameworkCore.Migrations;

namespace OAK.Migrations
{
    public partial class AddCodeColumnToAutorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Autors",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Autors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Autors");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Autors",
                newName: "Id");
        }
    }
}
