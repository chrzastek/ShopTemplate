using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTemplate.Migrations
{
    public partial class paymentTypeAddedToSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Description", "Enabled", "Name" },
                values: new object[,]
                {
                    { 1, "Transfer funds via bank transfer. May last up to couple of days.", true, "Bank transfer" },
                    { 2, "Pay with PayPal", true, "PayPal" },
                    { 3, "Provide us token from your bank system", true, "Token" },
                    { 4, "Pay by our own payment system", false, "ShopTemplate payment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
