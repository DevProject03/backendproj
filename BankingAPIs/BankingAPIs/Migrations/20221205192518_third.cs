using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingAPIs.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MidleName",
                table: "SignUps",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MidleName",
                table: "CustomerAccounts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidleName",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "MidleName",
                table: "CustomerAccounts");
        }
    }
}
