using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmTicketApp.Models
{
    public class Seat : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Row must be between 1 and 20")]
        [Display(Name = "Row Number")]
        public int Row { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Seat number must be between 1 and 20")]
        [Display(Name = "Seat Number")]
        public int SeatNumber { get; set; }

        [Required]
        [Display(Name = "Is Occupied")]
        public bool IsOccupied { get; set; } = false;

        [Display(Name = "Cinema Hall")]
        public int CinemaId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CinemaId")]
        public virtual Cinema Cinema { get; set; } = null!;

    }
}
