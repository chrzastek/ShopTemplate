using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTemplate.Migrations
{
    public partial class userMessageUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisteredUser",
                table: "UserMessages");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserMessages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_ApplicationUserId",
                table: "UserMessages",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_AspNetUsers_ApplicationUserId",
                table: "UserMessages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_AspNetUsers_ApplicationUserId",
                table: "UserMessages");

            migrationBuilder.DropIndex(
                name: "IX_UserMessages_ApplicationUserId",
                table: "UserMessages");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserMessages");

            migrationBuilder.AddColumn<bool>(
                name: "RegisteredUser",
                table: "UserMessages",
                nullable: false,
                defaultValue: false);
        }
    }
}
