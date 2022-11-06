using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Treaning.WebAPI.Migrations
{
    public partial class M001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Firstnam",
                table: "Teachers",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "Firstnam",
                table: "Students",
                newName: "Firstname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Teachers",
                newName: "Firstnam");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Students",
                newName: "Firstnam");
        }
    }
}
