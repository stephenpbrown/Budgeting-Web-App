namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubCategoryModels", "BudgetID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCategoryModels", "BudgetID");
        }
    }
}
