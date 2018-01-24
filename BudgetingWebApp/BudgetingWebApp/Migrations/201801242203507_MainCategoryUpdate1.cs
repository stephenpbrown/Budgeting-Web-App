namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainCategoryUpdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BudgetModels", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BudgetModels", "UserID", c => c.Int(nullable: false));
        }
    }
}
