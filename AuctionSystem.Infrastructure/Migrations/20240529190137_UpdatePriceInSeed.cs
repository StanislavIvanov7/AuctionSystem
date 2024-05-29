using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class UpdatePriceInSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InitialPrice", "LastPrice" },
                values: new object[] { 12000m, 20000m });

            migrationBuilder.UpdateData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 20000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InitialPrice", "LastPrice" },
                values: new object[] { 12.000m, 20.000m });

            migrationBuilder.UpdateData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 20.000m);
        }
    }
}
