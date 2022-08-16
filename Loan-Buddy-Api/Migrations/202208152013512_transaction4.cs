namespace Loan_Buddy_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "TransactionType", c => c.String(maxLength: 200));
            DropColumn("dbo.Transactions", "PaymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "PaymentType", c => c.String(maxLength: 200));
            DropColumn("dbo.Transactions", "TransactionType");
        }
    }
}
