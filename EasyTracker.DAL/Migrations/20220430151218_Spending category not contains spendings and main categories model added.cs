using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
    public partial class Spendingcategorynotcontainsspendingsandmaincategoriesmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "SpendingCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "SpendingCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "SpendingCategories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainSpendingCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSpendingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpendingCategories_UserId1",
                table: "SpendingCategories",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId1",
                table: "SpendingCategories",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId1",
                table: "SpendingCategories");

            migrationBuilder.DropTable(
                name: "MainSpendingCategories");

            migrationBuilder.DropIndex(
                name: "IX_SpendingCategories_UserId1",
                table: "SpendingCategories");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "SpendingCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SpendingCategories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "SpendingCategories");
        }
    }
}
