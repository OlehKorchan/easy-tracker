using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
	public partial class Seedfewspendingcategories : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Spendings_AspNetUsers_UserId",
				table: "Spendings");

			migrationBuilder.DropIndex(
				name: "IX_Spendings_UserId",
				table: "Spendings");

			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Spendings");

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

		protected override void Down(MigrationBuilder migrationBuilder)
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

			migrationBuilder.AddColumn<string>(
				name: "UserId",
				table: "Spendings",
				type: "nvarchar(450)",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Spendings_UserId",
				table: "Spendings",
				column: "UserId");

			migrationBuilder.AddForeignKey(
				name: "FK_Spendings_AspNetUsers_UserId",
				table: "Spendings",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}
	}
}
