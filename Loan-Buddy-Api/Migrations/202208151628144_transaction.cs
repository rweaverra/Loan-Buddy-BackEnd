namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction : DbMigration
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
                        LoanAgreement_LoanAgreementId = c.Int(),
                    })
                .PrimaryKey(t => t.LoanAgreementId)
                .ForeignKey("dbo.LoanAgreements", t => t.LoanAgreement_LoanAgreementId)
                .Index(t => t.LoanAgreement_LoanAgreementId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        LoanAgreementId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PaymentType = c.String(maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        RemainingTotal = c.Int(nullable: false),
                        ProofOfPayment = c.Boolean(nullable: false),
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
            DropForeignKey("dbo.LoanAgreements", "LoanAgreement_LoanAgreementId", "dbo.LoanAgreements");
            DropIndex("dbo.Transactions", new[] { "LoanAgreementId" });
            DropIndex("dbo.LoanAgreements", new[] { "LoanAgreement_LoanAgreementId" });
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.LoanAgreements");
        }
    }
}
