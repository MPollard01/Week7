using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreWebApp.Data.Migrations
{
    public partial class addedPaymentIntentToOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "OrderHeaders");
        }
    }
}
