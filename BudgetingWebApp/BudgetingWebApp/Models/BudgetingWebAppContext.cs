using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BudgetingWebApp.Models
{
    public class BudgetingWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BudgetingWebAppContext() : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<BudgetingWebApp.Models.BudgetModel> BudgetModels { get; set; }

        public System.Data.Entity.DbSet<BudgetingWebApp.Models.MainCategoryModel> MainCategoryModels { get; set; }
    }
}
