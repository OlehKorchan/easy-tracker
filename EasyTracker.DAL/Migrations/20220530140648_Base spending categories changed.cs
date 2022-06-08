using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
	public partial class Basespendingcategorieschanged : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "MainSpendingCategories",
				keyColumn: "Id",
				keyValue: new Guid("30f2e855-954a-45b5-840c-caecaa7170a6"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategories",
				keyColumn: "Id",
				keyValue: new Guid("77e94b73-f23b-45fa-bc84-2767855a8af5"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategories",
				keyColumn: "Id",
				keyValue: new Guid("815dbef1-6985-4cc0-861f-a4bdddd9b579"));

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

		protected override void Down(MigrationBuilder migrationBuilder)
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
				values: new object[] { new Guid("30f2e855-954a-45b5-840c-caecaa7170a6"), "Health", "", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.onlinewebfonts.com%2Ficon%2F445017&psig=AOvVaw0vm0cuvqoG2RBTR7oErxTk&ust=1653990981843000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCLDVltr6hvgCFQAAAAAdAAAAABAk" });

			migrationBuilder.InsertData(
				table: "MainSpendingCategories",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("77e94b73-f23b-45fa-bc84-2767855a8af5"), "Food", "", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.com%2Fpin%2F718605684275538858%2F&psig=AOvVaw00C9EAl4Atdy61_4esJoAC&ust=1653990470533000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCIiFn-z4hvgCFQAAAAAdAAAAABAK" });

			migrationBuilder.InsertData(
				table: "MainSpendingCategories",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("815dbef1-6985-4cc0-861f-a4bdddd9b579"), "Transport", "", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.transitsystems.com.au%2F&psig=AOvVaw2DbI0YDHXA4bt9jNx6VYF2&ust=1653990559697000&source=images&cd=vfe&ved=0CAwQjRxqFwoTCKj5oqf5hvgCFQAAAAAdAAAAABAb" });
		}
	}
}