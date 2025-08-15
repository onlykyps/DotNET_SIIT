using FilmTicketApp.Data;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
   public class Film
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string ImageURL { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
      public double Price { get; set; }
      public Actor[] Actors { get; set; }
      public Cinema Cinema { get; set; }
      public FilmGenre FilmGenre { get; set; }
   }
}
