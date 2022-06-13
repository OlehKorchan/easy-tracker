using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
	public partial class Adddifferentcurrenciessupport : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_BaseCurrencyRate_AspNetUsers_UserId",
				table: "BaseCurrencyRate");

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("89371614-c281-4487-adb6-f913283739d0"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("b16af40f-22f0-4670-a438-c9a3ef4a4112"));

			migrationBuilder.DeleteData(
				table: "MainSpendingCategory",
				keyColumn: "Id",
				keyValue: new Guid("e7462544-ecc5-4a43-8999-1a5280efe341"));

			migrationBuilder.CreateTable(
				name: "CurrencyBalance",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Currency = table.Column<int>(type: "int", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CurrencyBalance", x => x.Id);
					table.ForeignKey(
						name: "FK_CurrencyBalance_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

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

			migrationBuilder.CreateIndex(
				name: "IX_CurrencyBalance_UserId",
				table: "CurrencyBalance",
				column: "UserId");

			migrationBuilder.AddForeignKey(
				name: "FK_BaseCurrencyRate_AspNetUsers_UserId",
				table: "BaseCurrencyRate",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_BaseCurrencyRate_AspNetUsers_UserId",
				table: "BaseCurrencyRate");

			migrationBuilder.DropTable(
				name: "CurrencyBalance");

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
				values: new object[] { new Guid("89371614-c281-4487-adb6-f913283739d0"), "Transport", "", "https://images.squarespace-cdn.com/content/v1/5a668f1080bd5e34d18a7e76/1528433925491-J4AL2S34T9O2QNMGPQ0L/Public_Transport_02_2x.png?format=300w" });

			migrationBuilder.InsertData(
				table: "MainSpendingCategory",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("b16af40f-22f0-4670-a438-c9a3ef4a4112"), "Food", "", "https://i.pinimg.com/564x/fd/80/ec/fd80ecec48eba2a9adb76e4133905879.jpg" });

			migrationBuilder.InsertData(
				table: "MainSpendingCategory",
				columns: new[] { "Id", "CategoryName", "Description", "ImageSrc" },
				values: new object[] { new Guid("e7462544-ecc5-4a43-8999-1a5280efe341"), "Health", "", "https://pic.onlinewebfonts.com/svg/img_445017.png" });

			migrationBuilder.AddForeignKey(
				name: "FK_BaseCurrencyRate_AspNetUsers_UserId",
				table: "BaseCurrencyRate",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}
	}
}
