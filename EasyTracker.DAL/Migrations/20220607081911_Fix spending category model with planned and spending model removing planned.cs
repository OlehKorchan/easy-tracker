using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
    public partial class Fixspendingcategorymodelwithplannedandspendingmodelremovingplanned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_UserId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_AspNetUsers_UserId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId",
                table: "SpendingCategories");

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("2aef53fc-4c65-4dcd-89d7-b32864a10e5d"));

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("4613c9e1-50b7-4e0e-b055-95a6821991d3"));

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("47a40b38-1042-457f-a267-1bc84ccc51d8"));

            migrationBuilder.DropColumn(
                name: "PlannedAmount",
                table: "Spendings");

            migrationBuilder.RenameColumn(
                name: "SpendAmount",
                table: "Spendings",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Spendings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlannedAmount",
                table: "SpendingCategories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("384c0532-51db-440c-8e2b-5ce34576b45b"), "Food", "", "https://i.pinimg.com/564x/fd/80/ec/fd80ecec48eba2a9adb76e4133905879.jpg" });

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("647ee0c0-f7bf-423e-9875-e7453478e4f4"), "Health", "", "https://pic.onlinewebfonts.com/svg/img_445017.png" });

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("b2dfc110-7fb4-4bfb-89fd-d07890346a4a"), "Transport", "", "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w" });

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_UserId",
                table: "Salaries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_AspNetUsers_UserId",
                table: "Savings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId",
                table: "SpendingCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_UserId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_AspNetUsers_UserId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId",
                table: "SpendingCategories");

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("384c0532-51db-440c-8e2b-5ce34576b45b"));

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("647ee0c0-f7bf-423e-9875-e7453478e4f4"));

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("b2dfc110-7fb4-4bfb-89fd-d07890346a4a"));

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "PlannedAmount",
                table: "SpendingCategories");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Spendings",
                newName: "SpendAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "PlannedAmount",
                table: "Spendings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("2aef53fc-4c65-4dcd-89d7-b32864a10e5d"), "Transport", "", "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w" });

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("4613c9e1-50b7-4e0e-b055-95a6821991d3"), "Health", "", "https://pic.onlinewebfonts.com/svg/img_445017.png" });

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("47a40b38-1042-457f-a267-1bc84ccc51d8"), "Food", "", "https://i.pinimg.com/564x/fd/80/ec/fd80ecec48eba2a9adb76e4133905879.jpg" });

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_UserId",
                table: "Salaries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_AspNetUsers_UserId",
                table: "Savings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpendingCategories_AspNetUsers_UserId",
                table: "SpendingCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
