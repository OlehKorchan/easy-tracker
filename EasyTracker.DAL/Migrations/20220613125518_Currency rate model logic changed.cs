using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyTracker.DAL.Migrations
{
    public partial class Currencyratemodellogicchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("508b0dec-789b-48dd-b782-3b384bb79fad"));

            migrationBuilder.DropColumn(
                name: "ReverseRate",
                table: "BaseCurrencyRate");

            migrationBuilder.InsertData(
                table: "BaseCurrencyRate",
                columns: new[] { "Id", "Discriminator", "FromCurrency", "Rate", "ToCurrency" },
                values: new object[,]
                {
                    { new Guid("159dc525-ff91-49bd-abb5-510e6b614e82"), "BaseCurrencyRate", 3, 1.1699999999999999, 2 },
                    { new Guid("45f2cced-7f30-4dd8-830c-35b6139de59d"), "BaseCurrencyRate", 2, 1.0700000000000001, 1 },
                    { new Guid("4be152c9-8166-490e-a6a8-a760daea62cb"), "BaseCurrencyRate", 1, 1.0, 1 },
                    { new Guid("675301fc-2816-46eb-a0ae-47bb52ed4a19"), "BaseCurrencyRate", 0, 1.0, 0 },
                    { new Guid("6cc3b4e8-8535-4e83-b349-dc52e8ec1efb"), "BaseCurrencyRate", 3, 36.950000000000003, 0 },
                    { new Guid("701ec533-ea40-42ae-8ad0-fe934b9f76c4"), "BaseCurrencyRate", 3, 1.25, 1 },
                    { new Guid("840cf9ee-d0d3-4a65-b133-38b80b4de011"), "BaseCurrencyRate", 2, 1.0, 2 },
                    { new Guid("8e77b222-1d90-4a08-b503-ade87cb7eafc"), "BaseCurrencyRate", 3, 1.0, 3 },
                    { new Guid("b57128e9-e448-46cd-bfba-afef4d25985c"), "BaseCurrencyRate", 1, 29.5, 0 },
                    { new Guid("cb288c3f-f483-4259-8eb7-e6353d2a14ce"), "BaseCurrencyRate", 2, 31.59, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyBalance_Currency",
                table: "CurrencyBalance",
                column: "Currency",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CurrencyBalance_Currency",
                table: "CurrencyBalance");

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("159dc525-ff91-49bd-abb5-510e6b614e82"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("45f2cced-7f30-4dd8-830c-35b6139de59d"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("4be152c9-8166-490e-a6a8-a760daea62cb"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("675301fc-2816-46eb-a0ae-47bb52ed4a19"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("6cc3b4e8-8535-4e83-b349-dc52e8ec1efb"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("701ec533-ea40-42ae-8ad0-fe934b9f76c4"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("840cf9ee-d0d3-4a65-b133-38b80b4de011"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("8e77b222-1d90-4a08-b503-ade87cb7eafc"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("b57128e9-e448-46cd-bfba-afef4d25985c"));

            migrationBuilder.DeleteData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("cb288c3f-f483-4259-8eb7-e6353d2a14ce"));

            migrationBuilder.AddColumn<double>(
                name: "ReverseRate",
                table: "BaseCurrencyRate",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("379faee5-bde2-4cb6-8405-2e8e92f163bb"),
                column: "ReverseRate",
                value: 29.5);

            migrationBuilder.UpdateData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("392cb8c4-a96d-4cd8-bdd5-5c28a928f22b"),
                column: "ReverseRate",
                value: 1.1699999999999999);

            migrationBuilder.UpdateData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("51eb5043-ecde-4857-a27d-89af00265485"),
                column: "ReverseRate",
                value: 1.0700000000000001);

            migrationBuilder.UpdateData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("725b5521-ca03-4109-b230-5f17a0ea99dd"),
                column: "ReverseRate",
                value: 1.25);

            migrationBuilder.UpdateData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("d6f50313-3b89-45ae-9a9d-3577ef0230c3"),
                column: "ReverseRate",
                value: 36.950000000000003);

            migrationBuilder.UpdateData(
                table: "BaseCurrencyRate",
                keyColumn: "Id",
                keyValue: new Guid("dd015f02-7bb5-426c-9787-92cdec52abe7"),
                column: "ReverseRate",
                value: 31.59);

            migrationBuilder.InsertData(
                table: "BaseCurrencyRate",
                columns: new[] { "Id", "Discriminator", "FromCurrency", "Rate", "ReverseRate", "ToCurrency" },
                values: new object[] { new Guid("508b0dec-789b-48dd-b782-3b384bb79fad"), "BaseCurrencyRate", 0, 0.027, 36.950000000000003, 3 });
        }
    }
}
