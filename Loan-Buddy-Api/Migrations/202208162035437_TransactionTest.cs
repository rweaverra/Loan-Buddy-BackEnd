namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionTest : DbMigration
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
                        DateCreated = c.DateTime(nullable: false),
                        MonthlyPaymentAmount = c.Int(nullable: false),
                        RemainingTotal = c.Int(nullable: false),
                        SignedByBorrower = c.Boolean(nullable: false),
                        SignedByLender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LoanAgreementId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        TransactionType = c.String(maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        RemainingTotal = c.Int(nullable: false),
                        ProofOfPayment = c.Boolean(nullable: false),
                        LoanAgreementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.LoanAgreements", t => t.LoanAgreementId, cascadeDelete: true)
                .Index(t => t.LoanAgreementId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Password = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "LoanAgreementId", "dbo.LoanAgreements");
            DropIndex("dbo.Transactions", new[] { "LoanAgreementId" });
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.LoanAgreements");
        }
    }
}
