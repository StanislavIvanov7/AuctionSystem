using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class addedAuctionIdInBiddingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "Biddings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Auction Identifier");

            migrationBuilder.UpdateData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuctionId", "Price" },
                values: new object[] { 1, 160000m });

            migrationBuilder.CreateIndex(
                name: "IX_Biddings_AuctionId",
                table: "Biddings",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Biddings_Auctions_AuctionId",
                table: "Biddings",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biddings_Auctions_AuctionId",
                table: "Biddings");

            migrationBuilder.DropIndex(
                name: "IX_Biddings_AuctionId",
                table: "Biddings");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "Biddings");

            migrationBuilder.UpdateData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 20000m);
        }
    }
}
