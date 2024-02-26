using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class transactionupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                table: "Transactions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "ThirdPartyApp",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 31, 12, 45, 40, 871, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 31, 12, 45, 40, 871, DateTimeKind.Local).AddTicks(3914));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThirdPartyApp",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionType",
                table: "Transactions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 30, 20, 27, 12, 702, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 30, 20, 27, 12, 702, DateTimeKind.Local).AddTicks(8151));
        }
    }
}
