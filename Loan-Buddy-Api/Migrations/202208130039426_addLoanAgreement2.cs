namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoanAgreement2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanAgreements",
                c => new
                    {
                        LoanAgreementId = c.Int(nullable: false, identity: true),
                        LenderId = c.Int(nullable: false),
                        BorrowerId = c.Int(nullable: false),
                        OriginalAmount = c.Int(nullable: false),
                        DateCreated = c.String(maxLength: 50),
                        MonthlyPaymentAmount = c.Int(nullable: false),
                        RemainingTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanAgreementId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Password = c.String(maxLength: 200),
                        DateCreated = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.LoanAgreements");
        }
    }
}
