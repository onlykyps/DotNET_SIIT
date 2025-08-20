using FilmTicketApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
      //public Actor[] Actors { get; set; }


      [ForeignKey("CinemaID")]
      public Cinema Cinema { get; set; }
      public int CinemaID { get; set; }

      [ForeignKey("ProducerID")]
      public Producer Producer { get; set; }
      public int ProducerID { get; set; }

      public FilmGenre FilmGenre { get; set; }

      public List<ActorToFilm> FilmActors { get; set; }


   }
}
