using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LoanAgreements",
                columns: table => new
                {
                    LoanAgreementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalAmount = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyPaymentAmount = table.Column<int>(type: "int", nullable: false),
                    RemainingTotal = table.Column<int>(type: "int", nullable: false),
                    SignedByBorrower = table.Column<bool>(type: "bit", nullable: false),
                    SignedByLender = table.Column<bool>(type: "bit", nullable: false),
                    BorrowerId = table.Column<int>(type: "int", nullable: true),
                    LenderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAgreements", x => x.LoanAgreementId);
                    table.ForeignKey(
                        name: "FK_LoanAgreements_Users_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LoanAgreements_Users_LenderId",
                        column: x => x.LenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingTotal = table.Column<int>(type: "int", nullable: false),
                    ProofOfPayment = table.Column<bool>(type: "bit", nullable: false),
                    LoanAgreementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_LoanAgreements_LoanAgreementId",
                        column: x => x.LoanAgreementId,
                        principalTable: "LoanAgreements",
                        principalColumn: "LoanAgreementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { 1, "bill@gmail.com", "Bill", "password" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { 2, "Janet@gmail.com", "Janet", "password" });

            migrationBuilder.InsertData(
                table: "LoanAgreements",
                columns: new[] { "LoanAgreementId", "BorrowerId", "DateCreated", "LenderId", "MonthlyPaymentAmount", "OriginalAmount", "RemainingTotal", "SignedByBorrower", "SignedByLender" },
                values: new object[] { 1, 1, new DateTime(2022, 8, 16, 22, 5, 43, 6, DateTimeKind.Local).AddTicks(7636), 2, 240, 24242, 2424, false, false });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Date", "LoanAgreementId", "ProofOfPayment", "RemainingTotal", "TransactionType" },
                values: new object[] { 1, 55, new DateTime(2022, 8, 16, 22, 5, 43, 6, DateTimeKind.Local).AddTicks(7699), 1, false, 2324, "Cash" });

            migrationBuilder.CreateIndex(
                name: "IX_LoanAgreements_BorrowerId",
                table: "LoanAgreements",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanAgreements_LenderId",
                table: "LoanAgreements",
                column: "LenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LoanAgreementId",
                table: "Transactions",
                column: "LoanAgreementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "LoanAgreements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
