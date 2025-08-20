using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
   public class Actor
   {
      [Key]
      public int Id { get; set; }
      
      [Display(Name ="Profile Picture URL")]
      public string ProfilePicture { get; set; }

      [Display(Name = "Full Name")]
      public string FullName { get; set; }

      [Display(Name = "Biography")]
      public string Biography { get; set; }

      public List<ActorToFilm> ActorFilms { get; set; }
   }
}
