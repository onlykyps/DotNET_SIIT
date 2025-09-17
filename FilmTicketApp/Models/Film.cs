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

        [Required]
        [Display(Name = "Film name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Duration (minutes)")]
        public int DurationMinutes { get; set; }

        [Display(Name = "Genre")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Rating")]
        public string Rating { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Poster Image URL")]
        public string? PosterImageUrl { get; set; }

        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Display(Name = "Director")]
        public string? Director { get; set; }

        [Display(Name = "Language")]
        public string? Language { get; set; }

        [Display(Name = "Cast")]
        public string? Cast { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}
