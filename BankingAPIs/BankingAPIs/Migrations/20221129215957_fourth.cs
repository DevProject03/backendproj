using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingAPIs.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "transactionStatus",
                table: "Transcations",
                newName: "TransactionStat");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "SignUps",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "SignUps",
                newName: "Genders");

            migrationBuilder.RenameColumn(
                name: "accountType",
                table: "SignUps",
                newName: "AccountTypes");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "CustomerAccounts",
                newName: "Genders");

            migrationBuilder.RenameColumn(
                name: "accountType",
                table: "CustomerAccounts",
                newName: "AccountTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionStat",
                table: "Transcations",
                newName: "transactionStatus");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "SignUps",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Genders",
                table: "SignUps",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "AccountTypes",
                table: "SignUps",
                newName: "accountType");

            migrationBuilder.RenameColumn(
                name: "Genders",
                table: "CustomerAccounts",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "AccountTypes",
                table: "CustomerAccounts",
                newName: "accountType");
        }
    }
}
