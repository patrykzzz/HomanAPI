using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homan.DAL.Migrations
{
    public partial class RemoveHomeSpaceItemList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSpaceItems_HomeSpaceItemLists_HomeSpaceListId",
                table: "HomeSpaceItems");

            migrationBuilder.DropTable(
                name: "HomeSpaceItemLists");

            migrationBuilder.RenameColumn(
                name: "HomeSpaceListId",
                table: "HomeSpaceItems",
                newName: "HomeSpaceId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeSpaceItems_HomeSpaceListId",
                table: "HomeSpaceItems",
                newName: "IX_HomeSpaceItems_HomeSpaceId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "HomeSpaceItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "HomeSpaceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSpaceItems_HomeSpaces_HomeSpaceId",
                table: "HomeSpaceItems",
                column: "HomeSpaceId",
                principalTable: "HomeSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSpaceItems_HomeSpaces_HomeSpaceId",
                table: "HomeSpaceItems");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "HomeSpaceItems");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "HomeSpaceItems");

            migrationBuilder.RenameColumn(
                name: "HomeSpaceId",
                table: "HomeSpaceItems",
                newName: "HomeSpaceListId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeSpaceItems_HomeSpaceId",
                table: "HomeSpaceItems",
                newName: "IX_HomeSpaceItems_HomeSpaceListId");

            migrationBuilder.CreateTable(
                name: "HomeSpaceItemLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HomeSpaceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSpaceItemLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeSpaceItemLists_HomeSpaces_HomeSpaceId",
                        column: x => x.HomeSpaceId,
                        principalTable: "HomeSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeSpaceItemLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeSpaceItemLists_HomeSpaceId",
                table: "HomeSpaceItemLists",
                column: "HomeSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSpaceItemLists_UserId",
                table: "HomeSpaceItemLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSpaceItems_HomeSpaceItemLists_HomeSpaceListId",
                table: "HomeSpaceItems",
                column: "HomeSpaceListId",
                principalTable: "HomeSpaceItemLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
