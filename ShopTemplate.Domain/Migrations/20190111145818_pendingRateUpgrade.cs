using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTemplate.Migrations
{
    public partial class pendingRateUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PendingRates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PendingRates_ProductId",
                table: "PendingRates",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PendingRates_Products_ProductId",
                table: "PendingRates",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendingRates_Products_ProductId",
                table: "PendingRates");

            migrationBuilder.DropIndex(
                name: "IX_PendingRates_ProductId",
                table: "PendingRates");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PendingRates",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
