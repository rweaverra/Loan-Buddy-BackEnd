namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loanAgreementFK : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoanAgreements", "LenderId", c => c.Int());
            AlterColumn("dbo.LoanAgreements", "BorrowerId", c => c.Int());
            CreateIndex("dbo.LoanAgreements", "LenderId");
            CreateIndex("dbo.LoanAgreements", "BorrowerId");
            AddForeignKey("dbo.LoanAgreements", "BorrowerId", "dbo.Users", "UserId");
            AddForeignKey("dbo.LoanAgreements", "LenderId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanAgreements", "LenderId", "dbo.Users");
            DropForeignKey("dbo.LoanAgreements", "BorrowerId", "dbo.Users");
            DropIndex("dbo.LoanAgreements", new[] { "BorrowerId" });
            DropIndex("dbo.LoanAgreements", new[] { "LenderId" });
            AlterColumn("dbo.LoanAgreements", "BorrowerId", c => c.Int(nullable: false));
            AlterColumn("dbo.LoanAgreements", "LenderId", c => c.Int(nullable: false));
        }
    }
}
