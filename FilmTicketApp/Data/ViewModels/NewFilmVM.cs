using FilmTicketApp.Data.Base;
using FilmTicketApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmTicketApp.Models
{
   public class NewFilmVM
   {
      [Display(Name = "Film name")]
      public string Name { get; set; }

      [Display(Name = "Film description")]
      public string Description { get; set; }

      [Display(Name = "Film poster URL")]
      public string ImageURL { get; set; }

      [Display(Name = "Film start date")]
      public DateTime StartDate { get; set; }

      [Display(Name = "Film end date")]
      public DateTime EndDate { get; set; }

      [Display(Name = "Price in $")]
      public double Price { get; set; }

      [Display(Name = "Select a cinema")]
      public int CinemaID { get; set; }

      [Display(Name = "Select a producer")]
      public int ProducerID { get; set; }

      [Display(Name = "Select a genre")]
      public FilmGenre FilmGenre { get; set; }

      [Display(Name = "Select actor(s)")]
      public List<int> ActorIDs { get; set; }


   }
}
