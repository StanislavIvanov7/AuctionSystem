using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class InitialMigrationWithSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "User Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendingCommentUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Sending Comment User Identifier"),
                    ReceivingCommentUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Receiving Comment User Identifier"),
                    Content = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_AspNetUsers_ReceivingCommentUserId",
                        column: x => x.ReceivingCommentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComments_AspNetUsers_SendingCommentUserId",
                        column: x => x.SendingCommentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "User Comment Table");

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
                    BiddingCount = table.Column<int>(type: "int", nullable: false, comment: "Bidding Count"),
                    StartingAuctionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Starting Date And Time Of Auction"),
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
                name: "AuctionComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Auction Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false, comment: "Auction Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    Content = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionComments_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Auction Comment Table");

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

            migrationBuilder.CreateTable(
                name: "Biddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Bidding Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Buyer Identifier"),
                    AuctionId = table.Column<int>(type: "int", nullable: false, comment: "Auction Identifier"),
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
                    table.ForeignKey(
                        name: "FK_Biddings_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                },
                comment: "Bidding Table");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "346e1559-a879-404e-8555-4708cda20f06", "02672c13-8fc0-4f95-a0d6-2762a47062c1", "Moderator", "MODERATOR" },
                    { "9e42b0be-39c7-48bd-883b-10726fbd7573", "1dc1ba21-620d-4e97-a08a-535d97a9612f", "Customer", "CUSTOMER" },
                    { "e870b2a7-d550-4201-a4d6-a40bd996790a", "d37fb5f1-1c80-4fa2-bafe-e09185bf377a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Enable", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0a2830ef-8be3-4ef6-910b-33b680d659d3", 0, "c37f9e70-f9ff-4e55-8c95-83ce9708cef7", "stanislav@abv.bg", false, true, "Stanislav", "Ivanov", false, null, "STANISLAV@ABV.BG", "STANISLAV@ABV.BG", "AQAAAAEAACcQAAAAEKWMFkl7AX/tLiH5YsPsX3Dq/tpWz3nWir4Z3EZlGvPetA4BnxbplEiAgbvgoFmNyQ==", null, false, "9e406138-c088-4d10-810a-8cb287aa339b", false, "stanislav@abv.bg" },
                    { "0e136956-3e82-4e00-8f60-b274cdf40833", 0, "e105f213-ede3-4a80-842f-3c9dc11968f3", "petq@abv.bg", false, true, "Petq", "Ivanova", false, null, "PETQ@ABV.BG", "PETQ@ABV.BG", "AQAAAAEAACcQAAAAEA6z9dwlBH7tWOjytCxnRXyppvEkLyGpZe8kgTLmsSO42yDBQrsJcX4A5LG0ipmkvQ==", null, false, "ddfff353-d2cc-4d0c-a9cd-c40f2914296b", false, "petq@abv.bg" },
                    { "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", 0, "ec2261ab-a653-4698-bbf8-03187c3e1877", "teodor@abv.bg", false, true, "Teodor", "Ivanov", false, null, "TEODOR@ABV.BG", "TEODOR@ABV.BG", "AQAAAAEAACcQAAAAEMMvPmUxbEXmTzVVI3EVFNy2fXTYx/wYItqlFu70sMGcbHmXYNTsj2yXh37gHAe0Wg==", null, false, "d258ec24-1129-4a44-84b4-4597aecc18e9", false, "teodor@abv.bg" },
                    { "cd87d0e2-4047-473e-924a-3e10406c5583", 0, "ddd19b43-78e7-4f76-ada7-a863c26dda43", "pesho@abv.bg", false, true, "Pesho", "Ivanov", false, null, "PESHO@ABV.BG", "PESHO@ABV.BG", "AQAAAAEAACcQAAAAEI3Z0d7r2sGUdrya083s+YIwZL3gNHejHgWhjXmQNjNLr8k76kX/0rtfK6WclL10aQ==", null, false, "eccde9ba-4a3c-4bc1-9bee-3a8988b80b6f", false, "pesho@abv.bg" }
                });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e870b2a7-d550-4201-a4d6-a40bd996790a", "0a2830ef-8be3-4ef6-910b-33b680d659d3" },
                    { "346e1559-a879-404e-8555-4708cda20f06", "0e136956-3e82-4e00-8f60-b274cdf40833" },
                    { "9e42b0be-39c7-48bd-883b-10726fbd7573", "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" },
                    { "9e42b0be-39c7-48bd-883b-10726fbd7573", "cd87d0e2-4047-473e-924a-3e10406c5583" }
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "BiddingCount", "BiddingPeriodInDays", "ConditionId", "Description", "InitialPrice", "LastBuyerId", "LastPrice", "MinBiddingStep", "Name", "SellerId", "StartingAuctionDateTime" },
                values: new object[] { 1, 1, 5, 5, "Mercedes C200 2018 car for sale with a starting price of 12,000lv and a minimum bid of BGN 100.On actual kilometers without any remarks.", 12000m, "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", 20000m, 100, "Car auction", "cd87d0e2-4047-473e-924a-3e10406c5583", new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "Id", "Content", "ReceivingCommentUserId", "SendingCommentUserId" },
                values: new object[] { 1, "The best customer", "cd87d0e2-4047-473e-924a-3e10406c5583", "70280028-a1a0-4b5e-89d8-b4e65cbae8d8" });

            migrationBuilder.InsertData(
                table: "AuctionComments",
                columns: new[] { "Id", "AuctionId", "Content", "UserId" },
                values: new object[] { 6, 1, "Very good car", "cd87d0e2-4047-473e-924a-3e10406c5583" });

            migrationBuilder.InsertData(
                table: "AuctionImages",
                columns: new[] { "Id", "AuctionId", "ImageUrl", "IsMain" },
                values: new object[,]
                {
                    { 1, 1, "https://carsguide.ikman.lk/wp-content/uploads/2023/11/C200-scaled.jpg", true },
                    { 2, 1, "https://res.cloudinary.com/driveau/image/upload/v1616453173/cms/uploads/2018-mercedes-benz-c200-508.jpg", false },
                    { 3, 1, "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/15-mercedes-benz-c200-2018-review-static-rear.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "Biddings",
                columns: new[] { "Id", "AuctionId", "BuyerId", "DateAndTimeOfBidding", "Price" },
                values: new object[] { 1, 1, "70280028-a1a0-4b5e-89d8-b4e65cbae8d8", new DateTime(2024, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionComments_AuctionId",
                table: "AuctionComments",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionComments_UserId",
                table: "AuctionComments",
                column: "UserId");

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
                name: "IX_Biddings_AuctionId",
                table: "Biddings",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Biddings_BuyerId",
                table: "Biddings",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ReceivingCommentUserId",
                table: "UserComments",
                column: "ReceivingCommentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_SendingCommentUserId",
                table: "UserComments",
                column: "SendingCommentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuctionComments");

            migrationBuilder.DropTable(
                name: "AuctionImages");

            migrationBuilder.DropTable(
                name: "Biddings");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AuctionConditions");
        }
    }
}
