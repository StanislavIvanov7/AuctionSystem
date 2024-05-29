using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class SeededDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuctionConditions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Unregistered" },
                    { 2, "Awaiting approval" },
                    { 3, "Refused" },
                    { 4, "Active" },
                    { 5, "Finished" },
                    { 6, "Terminated" }
                });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "BuyerId", "DateAndTimeOfBidding", "Price" },
                values: new object[] { 1, "39fb9235-83a6-4bb9-9236-490a99f6bb83", new DateTime(2024, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.000m });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BiddingPeriodInDays", "ConditionId", "Description", "InitialPrice", "LastBuyerId", "LastPrice", "MinBiddingStep", "Name", "SellerId" },
                values: new object[] { 1, 5, 5, "Mercedes C200 2018 car for sale with a starting price of 12,000lv and a minimum bid of BGN 100.On actual kilometers without any remarks.", 12.000m, "39fb9235-83a6-4bb9-9236-490a99f6bb83", 20.000m, 100, "Car auction", "ea9548dc-aac6-49b5-abe1-561136ac48c7" });

            migrationBuilder.InsertData(
                table: "AuctionImages",
                columns: new[] { "Id", "AuctionId", "ImageUrl", "IsMain" },
                values: new object[] { 1, 1, "https://carsguide.ikman.lk/wp-content/uploads/2023/11/C200-scaled.jpg", true });

            migrationBuilder.InsertData(
                table: "AuctionImages",
                columns: new[] { "Id", "AuctionId", "ImageUrl", "IsMain" },
                values: new object[] { 2, 1, "https://res.cloudinary.com/driveau/image/upload/v1616453173/cms/uploads/2018-mercedes-benz-c200-508.jpg", false });

            migrationBuilder.InsertData(
                table: "AuctionImages",
                columns: new[] { "Id", "AuctionId", "ImageUrl", "IsMain" },
                values: new object[] { 3, 1, "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/15-mercedes-benz-c200-2018-review-static-rear.jpg", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuctionConditions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuctionConditions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuctionConditions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuctionConditions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuctionConditions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AuctionImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuctionImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuctionImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Biddings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuctionConditions",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
