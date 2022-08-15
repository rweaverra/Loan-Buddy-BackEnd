namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanAgreements", "LoanAgreement_LoanAgreementId", "dbo.LoanAgreements");
            DropIndex("dbo.LoanAgreements", new[] { "LoanAgreement_LoanAgreementId" });
            DropColumn("dbo.LoanAgreements", "LoanAgreement_LoanAgreementId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanAgreements", "LoanAgreement_LoanAgreementId", c => c.Int());
            CreateIndex("dbo.LoanAgreements", "LoanAgreement_LoanAgreementId");
            AddForeignKey("dbo.LoanAgreements", "LoanAgreement_LoanAgreementId", "dbo.LoanAgreements", "LoanAgreementId");
        }
    }
}
