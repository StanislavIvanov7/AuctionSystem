using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class AddedUserIdToAuctionCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuctionComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "AuctionId",
                table: "AuctionComments",
                type: "int",
                nullable: false,
                comment: "Auction Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Comment Identifier");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AuctionComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "User Identifier");

            migrationBuilder.InsertData(
                table: "AuctionComments",
                columns: new[] { "Id", "AuctionId", "Content", "UserId" },
                values: new object[] { 6, 1, "Very good car", "39fb9235-83a6-4bb9-9236-490a99f6bb83" });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionComments_UserId",
                table: "AuctionComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionComments_AspNetUsers_UserId",
                table: "AuctionComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionComments_AspNetUsers_UserId",
                table: "AuctionComments");

            migrationBuilder.DropIndex(
                name: "IX_AuctionComments_UserId",
                table: "AuctionComments");

            migrationBuilder.DeleteData(
                table: "AuctionComments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AuctionComments");

            migrationBuilder.AlterColumn<int>(
                name: "AuctionId",
                table: "AuctionComments",
                type: "int",
                nullable: false,
                comment: "Comment Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Auction Identifier");

            migrationBuilder.InsertData(
                table: "AuctionComments",
                columns: new[] { "Id", "AuctionId", "Content" },
                values: new object[] { 1, 1, "Very good car" });
        }
    }
}
