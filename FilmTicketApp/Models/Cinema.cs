using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
   public class Cinema: IEntityBase
   {
      [Key]
      public int Id { get; set; }

      [Display(Name = "Logo")]
      public string Logo { get; set; }

      [Display(Name = "Name")]
      public string Name { get; set; }

      [Display(Name = "Description")]
      public string Description { get; set; }

      public List<Film>? Films { get; set; }
   }
}
