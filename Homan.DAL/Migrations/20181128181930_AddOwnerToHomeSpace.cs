using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homan.DAL.Migrations
{
    public partial class AddOwnerToHomeSpace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSpaces_Users_UserId",
                table: "HomeSpaces");

            migrationBuilder.DropIndex(
                name: "IX_HomeSpaces_UserId",
                table: "HomeSpaces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HomeSpaces");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "HomeSpaces",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HomeSpaces_OwnerId",
                table: "HomeSpaces",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSpaces_Users_OwnerId",
                table: "HomeSpaces",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSpaces_Users_OwnerId",
                table: "HomeSpaces");

            migrationBuilder.DropIndex(
                name: "IX_HomeSpaces_OwnerId",
                table: "HomeSpaces");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "HomeSpaces");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "HomeSpaces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeSpaces_UserId",
                table: "HomeSpaces",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSpaces_Users_UserId",
                table: "HomeSpaces",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
