using FilmTicketApp.Data.Base;
using FilmTicketApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmTicketApp.Models
{
    public class Film : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //public string ImageURL { get; set; }

        [Display(Name = "Poster Image URL")]
        public string? PosterImageUrl { get; set; }

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

        [Display(Name = "Genre")]
        public string Genre { get; set; } = string.Empty;

        public List<ActorToFilm> FilmActors { get; set; }

        [Display(Name = "Duration (minutes)")]
        public int DurationMinutes { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Cast")]
        public string? Cast { get; set; }

        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Display(Name = "Rating")]
        public string Rating { get; set; } = string.Empty;

        [Display(Name = "Director")]
        public string? Director { get; set; }

    }
}
