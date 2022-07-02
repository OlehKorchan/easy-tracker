using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations;

public partial class Changecurrencybalanceconstraintfromonecurrencyfieldtocomposecurrencyplususerid : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_CurrencyBalance_Currency",
            table: "CurrencyBalance");

        migrationBuilder.CreateIndex(
            name: "IX_CurrencyBalance_Currency_UserId",
            table: "CurrencyBalance",
            columns: new[] { "Currency", "UserId" },
            unique: true,
            filter: "[UserId] IS NOT NULL");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_CurrencyBalance_Currency_UserId",
            table: "CurrencyBalance");

        migrationBuilder.CreateIndex(
            name: "IX_CurrencyBalance_Currency",
            table: "CurrencyBalance",
            column: "Currency",
            unique: true);
    }
}
