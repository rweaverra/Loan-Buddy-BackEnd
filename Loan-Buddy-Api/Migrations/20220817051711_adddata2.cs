using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class adddata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 16, 23, 17, 11, 224, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 16, 23, 17, 11, 224, DateTimeKind.Local).AddTicks(8619));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 16, 22, 5, 43, 6, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 16, 22, 5, 43, 6, DateTimeKind.Local).AddTicks(7699));
        }
    }
}
