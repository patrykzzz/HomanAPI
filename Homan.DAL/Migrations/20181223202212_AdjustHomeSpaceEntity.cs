using Microsoft.EntityFrameworkCore.Migrations;

namespace Homan.DAL.Migrations
{
    public partial class AdjustHomeSpaceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "HomeSpaces",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "HomeSpaces",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "HomeSpaces");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "HomeSpaces",
                newName: "Description");
        }
    }
}
