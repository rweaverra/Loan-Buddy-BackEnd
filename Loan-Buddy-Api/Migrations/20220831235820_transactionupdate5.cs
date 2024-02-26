using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class transactionupdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RemainingTotal",
                table: "LoanAgreements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalAmount",
                table: "LoanAgreements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyPaymentAmount",
                table: "LoanAgreements",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MonthlyPaymentAmount", "OriginalAmount", "RemainingTotal" },
                values: new object[] { new DateTime(2022, 8, 31, 17, 58, 20, 202, DateTimeKind.Local).AddTicks(6270), 240m, 24242m, 2424m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 31, 17, 58, 20, 202, DateTimeKind.Local).AddTicks(6328));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RemainingTotal",
                table: "LoanAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginalAmount",
                table: "LoanAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonthlyPaymentAmount",
                table: "LoanAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                columns: new[] { "DateCreated", "MonthlyPaymentAmount", "OriginalAmount", "RemainingTotal" },
                values: new object[] { new DateTime(2022, 8, 31, 17, 45, 21, 725, DateTimeKind.Local).AddTicks(1622), 240, 24242, 2424 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 31, 17, 45, 21, 725, DateTimeKind.Local).AddTicks(1723));
        }
    }
}
