namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseModels",
                c => new
                    {
                        ExpenseModelID = c.Int(nullable: false, identity: true),
                        MainCategoryID = c.Int(nullable: true),
                        SubCategoryID = c.Int(nullable: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExpenseModelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExpenseModels");
        }
    }
}
