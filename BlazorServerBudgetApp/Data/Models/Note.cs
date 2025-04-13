using Microsoft.VisualBasic;

namespace BlazorServerBudgetApp.Data.Models
{
   public class Note
   {
      public int Id { get; set; }

      public string Description { get; set; } = string.Empty;

      public DateAndTime? DateAdded { get; set; }

   }
}
