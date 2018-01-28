namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BudgetModelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BudgetModels", "BudgetMonth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BudgetModels", "BudgetMonth", c => c.DateTime(nullable: false));
        }
    }
}
