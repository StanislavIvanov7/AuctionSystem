using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class AddedAuctionCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Auction Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionId = table.Column<int>(type: "int", nullable: false, comment: "Comment Identifier"),
                    Content = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionComments_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Auction Comment Table");

            migrationBuilder.InsertData(
                table: "AuctionComments",
                columns: new[] { "Id", "AuctionId", "Content" },
                values: new object[] { 1, 1, "Very good car" });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionComments_AuctionId",
                table: "AuctionComments",
                column: "AuctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionComments");
        }
    }
}
