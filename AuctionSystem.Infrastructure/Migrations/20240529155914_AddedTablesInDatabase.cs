using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class AddedTablesInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Condition Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Auction Condition Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionConditions", x => x.Id);
                },
                comment: "Auction Condition table");

            migrationBuilder.CreateTable(
                name: "Biddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Bidding Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer Identifier"),
                    DateAndTimeOfBidding = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date And Time Of Bidding"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Bidding Price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biddings_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Bidding Table");

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Auction Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Auction Name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Auction Description"),
                    InitialPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Auction Initial Price"),
                    MinBiddingStep = table.Column<int>(type: "int", nullable: false, comment: "Auction Min Bidding Step"),
                    BiddingPeriodInDays = table.Column<int>(type: "int", nullable: false, comment: "Auction Bidding Period In Days"),
                    ConditionId = table.Column<int>(type: "int", nullable: false, comment: "Auction Condition Identifier"),
                    SellerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Auction Seller Identifier"),
                    LastPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Auction Last Price"),
                    LastBuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Auction Last Buyer Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_AspNetUsers_LastBuyerId",
                        column: x => x.LastBuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Auctions_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auctions_AuctionConditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "AuctionConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Auction table");

            migrationBuilder.CreateTable(
                name: "AuctionImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Image Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "Image Url"),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, comment: "Is Main Image"),
                    AuctionId = table.Column<int>(type: "int", nullable: false, comment: "Auction Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionImages_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Auction Image Table");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionImages_AuctionId",
                table: "AuctionImages",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ConditionId",
                table: "Auctions",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_LastBuyerId",
                table: "Auctions",
                column: "LastBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Biddings_BuyerId",
                table: "Biddings",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionImages");

            migrationBuilder.DropTable(
                name: "Biddings");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "AuctionConditions");
        }
    }
}
