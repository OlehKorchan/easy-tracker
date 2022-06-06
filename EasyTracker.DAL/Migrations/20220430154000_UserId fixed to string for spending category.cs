using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
    public partial class UserIdfixedtostringforspendingcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId1",
                table: "SpendingCategories");

            migrationBuilder.DropIndex(
                name: "IX_SpendingCategories_UserId1",
                table: "SpendingCategories");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "SpendingCategories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SpendingCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingCategories_UserId",
                table: "SpendingCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId",
                table: "SpendingCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId",
                table: "SpendingCategories");

            migrationBuilder.DropIndex(
                name: "IX_SpendingCategories_UserId",
                table: "SpendingCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "SpendingCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "SpendingCategories",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
