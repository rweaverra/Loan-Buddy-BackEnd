using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class restart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 31, 17, 59, 38, 285, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 31, 17, 59, 38, 285, DateTimeKind.Local).AddTicks(6348));
        }
    }
}
