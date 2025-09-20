using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
   public class Actor: IEntityBase
   {
      [Key]
      public int Id { get; set; }
      
      [Display(Name ="Profile Picture")]
      [Required(ErrorMessage ="Profile picture is required")]
      public string ProfilePicture { get; set; }

      [Display(Name = "Full Name")]
      [Required(ErrorMessage = "Full Name is required")]
      public string FullName { get; set; }

      [Display(Name = "Biography")]
      [Required(ErrorMessage = "Biographyis required")]
      public string Biography { get; set; }

      //public List<ActorToFilm>? ActorFilms { get; set; }
   }
}
