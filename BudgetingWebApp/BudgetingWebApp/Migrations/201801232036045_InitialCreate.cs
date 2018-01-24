namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetModels",
                c => new
                    {
                        BudgetID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        BudgetMonth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BudgetModels");
        }
    }
}
