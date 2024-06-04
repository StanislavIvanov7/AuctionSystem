using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class ChangedBiddingConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 160000m);
        }
    }
}
