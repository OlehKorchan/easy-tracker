using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
    public partial class Basespendingcategorieschanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("1d37988b-a24c-4963-aec3-354c2dd2c6ce"));

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("f3b15050-7b93-44ee-b673-db641c6fb31c"));

            migrationBuilder.DeleteData(
                table: "MainSpendingCategories",
                keyColumn: "Id",
                keyValue: new Guid("f9054396-aafd-4f97-934a-88306b3dccfa"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("1d37988b-a24c-4963-aec3-354c2dd2c6ce"), "Food", "", "https://lh3.googleusercontent.com/supy4E8uKLWnxd91WiQpmE2Q-WJAsH55mr7FH7H7U2AMHfjuxzHNq6a5q3E5vdyBKpllT_XSaj8IqplKGU1OdmKwqU11VY6BHpBcCZ6NNscGa6W9J3zxo4DueCfgRKNqW-aT86Gy=w2400" });

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("f3b15050-7b93-44ee-b673-db641c6fb31c"), "Health", "", "https://pic.onlinewebfonts.com/svg/img_445017.png" });

            migrationBuilder.InsertData(
                table: "MainSpendingCategories",
                columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
                values: new object[] { new Guid("f9054396-aafd-4f97-934a-88306b3dccfa"), "Transport", "", "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w" });
        }
    }
}
