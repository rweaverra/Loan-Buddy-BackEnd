using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class transactionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProofOfPayment",
                table: "Transactions",
                newName: "RequiresProofOfPayment");

            migrationBuilder.AddColumn<int>(
                name: "ProofOfPaymentId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofOfPaymentId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "RequiresProofOfPayment",
                table: "Transactions",
                newName: "ProofOfPayment");

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
    }
}
