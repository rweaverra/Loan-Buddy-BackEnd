namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "LoanAgreementId", "dbo.LoanAgreements");
            DropIndex("dbo.Transactions", new[] { "LoanAgreementId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Transactions", "LoanAgreementId");
            AddForeignKey("dbo.Transactions", "LoanAgreementId", "dbo.LoanAgreements", "LoanAgreementId", cascadeDelete: true);
        }
    }
}
