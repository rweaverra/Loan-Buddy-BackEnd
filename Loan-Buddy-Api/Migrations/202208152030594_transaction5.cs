namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanAgreements", "SignedByBorrower", c => c.Boolean(nullable: false));
            AddColumn("dbo.LoanAgreements", "SignedByLender", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LoanAgreements", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoanAgreements", "DateCreated", c => c.String(maxLength: 50));
            DropColumn("dbo.LoanAgreements", "SignedByLender");
            DropColumn("dbo.LoanAgreements", "SignedByBorrower");
        }
    }
}
