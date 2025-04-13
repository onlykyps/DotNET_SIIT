using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerBudgetApp.Data.Models
{
   public class Fund
   {
      public int Id { get; set; }
      [Required]

      public decimal Amount { get; set; }
      [Required]

      public DateAndTime? DateAdded { get; set; }
   }
}
