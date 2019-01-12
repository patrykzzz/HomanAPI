using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homan.DAL.Migrations
{
    public partial class AddCreatedOnToHomeSpaceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "HomeSpaceItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "HomeSpaceItems");
        }
    }
}
