using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Models
{
    public enum TicketCategory
    {
        Full = 1,
        FullWith3D = 2,
        Reduced = 3,
        ReducedWith3D = 4
    }

    public class TicketType : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ticket Category")]
        public TicketCategory Category { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Is 3D")]
        public bool Is3D { get; set; }

        [Display(Name = "Is Reduced Price")]
        public bool IsReduced { get; set; }

        public virtual ICollection<TicketReservation> Reservations { get; set; } = new List<TicketReservation>();
    }
}