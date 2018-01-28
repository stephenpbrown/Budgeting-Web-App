using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetingWebApp.Models
{
    public class ExpenseModel
    {
        [Key]
        public int ExpenseModelID { get; set; }
        //[ForeignKey("MainCategoryID")]
        public int MainCategoryID { get; set; }
        //[ForeignKey("SubCategoryID")]
        public int SubCategoryID { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}