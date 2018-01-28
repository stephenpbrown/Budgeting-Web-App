using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetingWebApp.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int SubCategoryID { get; set; }
        public int MainCategoryID { get; set; }
        public string Name { get; set; }
        public decimal Allotment { get; set; }
        public decimal Actual { get; set; }
    }
}