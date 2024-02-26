using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class transactionupdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RemainingTotal",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                columns: new[] { "Date", "RemainingTotal" },
                values: new object[] { new DateTime(2022, 8, 31, 17, 59, 38, 285, DateTimeKind.Local).AddTicks(6348), 2324m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RemainingTotal",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 31, 17, 58, 20, 202, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                columns: new[] { "Date", "RemainingTotal" },
                values: new object[] { new DateTime(2022, 8, 31, 17, 58, 20, 202, DateTimeKind.Local).AddTicks(6328), 2324 });
        }
    }
}
