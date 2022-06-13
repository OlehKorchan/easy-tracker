using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
	public partial class Imagesforcategorieschangedtomaterialicons : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("33a3e088-8ff4-4b6b-97bb-e03e002c68f8"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("5134a9d8-2c6d-4155-8c6b-033baa74a928"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("64f01fc5-b710-4b0f-b7fb-5f96f4d04576"));

			migrationBuilder.InsertData(
				table: "MainSpendingCategory",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[,]
				{
					{ new Guid("0449468f-bc04-4423-97e4-2e56826f5cc1"), "Other", null, "info" },
					{ new Guid("2553d9c5-f104-49a3-80af-a27eb32fc274"), "Technics", null, "android" },
					{ new Guid("a3e814b2-5698-4d4e-be03-772b295e47ce"), "Restaurants", null, "restaurant" },
					{ new Guid("bac73f2d-5456-4b26-a7eb-387852cfee66"), "Transport", null, "train" },
					{ new Guid("e3c2a39d-ac7e-477c-aed1-d6586e6c27d6"), "Health", null, "healing" },
					{ new Guid("ea9208e8-3838-49ce-80ad-468cea820b86"), "Food", null, "fastfood" }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("0449468f-bc04-4423-97e4-2e56826f5cc1"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("2553d9c5-f104-49a3-80af-a27eb32fc274"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("a3e814b2-5698-4d4e-be03-772b295e47ce"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("bac73f2d-5456-4b26-a7eb-387852cfee66"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("e3c2a39d-ac7e-477c-aed1-d6586e6c27d6"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("ea9208e8-3838-49ce-80ad-468cea820b86"));

			migrationBuilder.InsertData(
				table: "MainSpendingCategory",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("33a3e088-8ff4-4b6b-97bb-e03e002c68f8"), "Transport", "", "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w" });

			migrationBuilder.InsertData(
				table: "MainSpendingCategory",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("5134a9d8-2c6d-4155-8c6b-033baa74a928"), "Health", "", "https://pic.onlinewebfonts.com/svg/img_445017.png" });

			migrationBuilder.InsertData(
				table: "MainSpendingCategory",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("64f01fc5-b710-4b0f-b7fb-5f96f4d04576"), "Food", "", "https://i.pinimg.com/564x/fd/80/ec/fd80ecec48eba2a9adb76e4133905879.jpg" });
		}
	}
}
