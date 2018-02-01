using BudgetingWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BudgetingWebApp.Models
{
    public class BudgetModel
    {
        [Key]
        public int BudgetID { get; set; }
        public string UserID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DisplayName("Budget Month/Year")]
        [DataType(DataType.Date)]
        public string BudgetMonth { get; set; }
    }
}