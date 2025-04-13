using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerBudgetApp.Data.Models
{
   public class Expense
   {
      public int Id { get; set; }
      [Required, StringLength(100, MinimumLength=3)]

      public string Name { get; set; }
      [Required]

      public decimal Amount { get; set; }
      [Required]

      public DateAndTime? DateAdded { get; set; }

   }
}
