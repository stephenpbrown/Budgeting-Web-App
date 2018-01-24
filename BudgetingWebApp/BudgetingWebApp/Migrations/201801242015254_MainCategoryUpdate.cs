namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainCategoryUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainCategoryModels", "BudgetID", c => c.Int(nullable: false));
            AddColumn("dbo.MainCategoryModels", "Name", c => c.String());
            AddColumn("dbo.MainCategoryModels", "Allotment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MainCategoryModels", "Actual", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainCategoryModels", "Actual");
            DropColumn("dbo.MainCategoryModels", "Allotment");
            DropColumn("dbo.MainCategoryModels", "Name");
            DropColumn("dbo.MainCategoryModels", "BudgetID");
        }
    }
}
