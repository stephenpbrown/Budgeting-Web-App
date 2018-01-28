namespace BudgetingWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubCategoryModels",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        MainCategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        Allotment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Actual = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SubCategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubCategoryModels");
        }
    }
}
