using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loan_Buddy_Api.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 155, "Carl@gmail.com", "Carl" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 156, "Karen@gmail.com", "Karen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name" },
                values: new object[] { 157, "Joe@gmail.com", "Joe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
