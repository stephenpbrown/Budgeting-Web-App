namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainCategory1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainCategoryModels",
                c => new
                    {
                        MainCategoryID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MainCategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MainCategoryModels");
        }
    }
}
