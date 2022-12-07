using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingAPIs.Migrations
{
    public partial class dbss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genders",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "Genders",
                table: "CustomerAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genders",
                table: "SignUps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Genders",
                table: "CustomerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
