using System.ComponentModel.DataAnnotations;

namespace BudgetingWebApp.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name ="Your Name")]
        public string FromName { get; set; }

        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        public string Message { get; set; }
    }
}