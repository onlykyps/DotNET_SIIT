using FilmTicketApp.Models;

namespace FilmTicketApp.Data.ViewModels
{
   public class NewFilmDropdownsVM
   {
      public NewFilmDropdownsVM()
      {
         Producers = new List<Producer>();
         Cinemas = new List<Cinema>();
         Actors = new List<Actor>();
      }


      public List<Producer> Producers { get; set; }
      public List<Actor> Actors { get; set; }
      public List<Cinema> Cinemas { get; set; }
   }
}
