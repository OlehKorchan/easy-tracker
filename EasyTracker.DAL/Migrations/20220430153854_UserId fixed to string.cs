using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
	public partial class UserIdfixedtostring : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Salaries_AspNetUsers_UserId1",
				table: "Salaries");

			migrationBuilder.DropForeignKey(
				name: "FK_Savings_AspNetUsers_UserId1",
				table: "Savings");

			migrationBuilder.DropForeignKey(
				name: "FK_Spendings_AspNetUsers_UserId1",
				table: "Spendings");

			migrationBuilder.DropIndex(
				name: "IX_Spendings_UserId1",
				table: "Spendings");

			migrationBuilder.DropIndex(
				name: "IX_Savings_UserId1",
				table: "Savings");

			migrationBuilder.DropIndex(
				name: "IX_Salaries_UserId1",
				table: "Salaries");

			migrationBuilder.DropColumn(
				name: "UserId1",
				table: "Spendings");

			migrationBuilder.DropColumn(
				name: "UserId1",
				table: "Savings");

			migrationBuilder.DropColumn(
				name: "UserId1",
				table: "Salaries");

			migrationBuilder.AlterColumn<string>(
				name: "UserId",
				table: "Spendings",
				type: "nvarchar(450)",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier");

			migrationBuilder.AlterColumn<string>(
				name: "UserId",
				table: "Savings",
				type: "nvarchar(450)",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier");

			migrationBuilder.AlterColumn<string>(
				name: "UserId",
				table: "Salaries",
				type: "nvarchar(450)",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier");

			migrationBuilder.CreateIndex(
				name: "IX_Spendings_UserId",
				table: "Spendings",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Savings_UserId",
				table: "Savings",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Salaries_UserId",
				table: "Salaries",
				column: "UserId");

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
				name: "FK_Spendings_AspNetUsers_UserId",
				table: "Spendings",
				column: "UserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
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
				name: "FK_Spendings_AspNetUsers_UserId",
				table: "Spendings");

			migrationBuilder.DropIndex(
				name: "IX_Spendings_UserId",
				table: "Spendings");

			migrationBuilder.DropIndex(
				name: "IX_Savings_UserId",
				table: "Savings");

			migrationBuilder.DropIndex(
				name: "IX_Salaries_UserId",
				table: "Salaries");

			migrationBuilder.AlterColumn<Guid>(
				name: "UserId",
				table: "Spendings",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldNullable: true);

			migrationBuilder.AddColumn<string>(
				name: "UserId1",
				table: "Spendings",
				type: "nvarchar(450)",
				nullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "UserId",
				table: "Savings",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldNullable: true);

			migrationBuilder.AddColumn<string>(
				name: "UserId1",
				table: "Savings",
				type: "nvarchar(450)",
				nullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "UserId",
				table: "Salaries",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldNullable: true);

			migrationBuilder.AddColumn<string>(
				name: "UserId1",
				table: "Salaries",
				type: "nvarchar(450)",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Spendings_UserId1",
				table: "Spendings",
				column: "UserId1");

			migrationBuilder.CreateIndex(
				name: "IX_Savings_UserId1",
				table: "Savings",
				column: "UserId1");

			migrationBuilder.CreateIndex(
				name: "IX_Salaries_UserId1",
				table: "Salaries",
				column: "UserId1");

			migrationBuilder.AddForeignKey(
				name: "FK_Salaries_AspNetUsers_UserId1",
				table: "Salaries",
				column: "UserId1",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Savings_AspNetUsers_UserId1",
				table: "Savings",
				column: "UserId1",
				principalTable: "AspNetUsers",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Spendings_AspNetUsers_UserId1",
				table: "Spendings",
				column: "UserId1",
				principalTable: "AspNetUsers",
				principalColumn: "Id");
		}
	}
}
