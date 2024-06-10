using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class ChangeAuctionAndBiddingSeedInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BiddingCount", "LastBuyerId", "SellerId" },
                values: new object[] { 1, "7930926e-9ca6-4c83-8921-bb432b90c8f6", "39fb9235-83a6-4bb9-9236-490a99f6bb83" });

            migrationBuilder.UpdateData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyerId",
                value: "7930926e-9ca6-4c83-8921-bb432b90c8f6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BiddingCount", "LastBuyerId", "SellerId" },
                values: new object[] { 5, "39fb9235-83a6-4bb9-9236-490a99f6bb83", "ea9548dc-aac6-49b5-abe1-561136ac48c7" });

            migrationBuilder.UpdateData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                column: "BuyerId",
                value: "39fb9235-83a6-4bb9-9236-490a99f6bb83");
        }
    }
}
