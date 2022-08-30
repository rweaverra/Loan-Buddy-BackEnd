using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class nullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RemainingTotal",
                table: "LoanAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OriginalAmount",
                table: "LoanAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MonthlyPaymentAmount",
                table: "LoanAgreements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "LoanAgreements",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 23, 17, 8, 5, 971, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 23, 17, 8, 5, 971, DateTimeKind.Local).AddTicks(8752));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RemainingTotal",
                table: "LoanAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginalAmount",
                table: "LoanAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonthlyPaymentAmount",
                table: "LoanAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "LoanAgreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LoanAgreements",
                keyColumn: "LoanAgreementId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 8, 22, 15, 22, 46, 830, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 22, 15, 22, 46, 830, DateTimeKind.Local).AddTicks(9599));
        }
    }
}
