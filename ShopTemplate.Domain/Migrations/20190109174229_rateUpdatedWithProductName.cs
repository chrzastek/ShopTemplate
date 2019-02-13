using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTemplate.Migrations
{
    public partial class rateUpdatedWithProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Rates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Rates");
        }
    }
}
