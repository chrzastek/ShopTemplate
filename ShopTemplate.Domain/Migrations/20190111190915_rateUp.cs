using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTemplate.Migrations
{
    public partial class rateUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Rates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Rates",
                nullable: true);
        }
    }
}
