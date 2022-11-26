using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Treaning.WebAPI.Migrations
{
    public partial class M003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Students",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Students");
        }
    }
}
