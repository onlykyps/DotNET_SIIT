namespace FilmTicketApp.Models
{
   public class ActorToFilm
   {
      public int FilmID { get; set; }
      public int ActorID { get; set; }

      public Film Film { get; set; }
      public Actor Actor { get; set; }
   }
}
