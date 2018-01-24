using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace BudgetingWebApp.Models
{
    public class MainCategoryModel
    {
        [Key]
        public int MainCategoryID { get; set; }
        //[ForeignKey("BudgetID")]
        public int BudgetID { get; set; }
        public string Name { get; set; }
        public decimal Allotment { get; set; }
        public decimal Actual { get; set; }
    }
}