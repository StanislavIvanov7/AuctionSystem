using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Infrastructure.Migrations
{
    public partial class AddedUserCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "UserComments",
                columns: new[] { "Id", "Content", "ReceivingCommentUserId", "SendingCommentUserId" },
                values: new object[] { 1, "The best customer", "39fb9235-83a6-4bb9-9236-490a99f6bb83", "9e4d170a-cfb8-4e35-b754-7f9586f48ce4" });

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
                name: "UserComments");
        }
    }
}
