using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class loanCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoanCreator",
                table: "LoanAgreements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "LoanCreator" },
                values: new object[] { new DateTime(2022, 9, 1, 11, 33, 9, 831, DateTimeKind.Local).AddTicks(5593), "" });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 9, 1, 11, 33, 9, 831, DateTimeKind.Local).AddTicks(5646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanCreator",
                table: "LoanAgreements");

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 31, 18, 3, 1, 698, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 31, 18, 3, 1, 698, DateTimeKind.Local).AddTicks(5682));
        }
    }
}
