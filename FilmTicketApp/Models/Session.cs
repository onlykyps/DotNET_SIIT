using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmTicketApp.Models
{
    public class Session : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Session Date")]
        public DateTime SessionDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign Keys
        [Required]
        [Display(Name = "Film")]
        public int FilmId { get; set; }

        [Required]
        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }

        // Navigation properties
        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; } = null!;

        [ForeignKey("CinemaId")]
        public virtual Cinema Cinema { get; set; } = null!;

        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public virtual ICollection<TicketReservation> TicketReservations { get; set; } = new List<TicketReservation>();

        // Computed properties
        [NotMapped]
        public DateTime SessionDateTime => SessionDate.Date + StartTime;

        [NotMapped]
        public string DisplayTime => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";

        [NotMapped]
        public bool IsExpired => DateTime.Now > SessionDateTime.AddMinutes(30); // 30 min grace period
    }

}