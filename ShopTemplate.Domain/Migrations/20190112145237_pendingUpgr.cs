using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTemplate.Migrations
{
    public partial class pendingUpgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PendingRates",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendingRates_UserId",
                table: "PendingRates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PendingRates_AspNetUsers_UserId",
                table: "PendingRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendingRates_AspNetUsers_UserId",
                table: "PendingRates");

            migrationBuilder.DropIndex(
                name: "IX_PendingRates_UserId",
                table: "PendingRates");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PendingRates",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
