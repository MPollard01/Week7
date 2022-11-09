using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreWebApp.Data.Migrations
{
    public partial class addedPhoneNumberOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "OrderHeaders");
        }
    }
}
