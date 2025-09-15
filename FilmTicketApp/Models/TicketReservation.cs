using FilmTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace FilmTicketApp.Models
{
    public class TicketReservation : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Seat")]
        public int SeatId { get; set; }

        [Required]
        [Display(Name = "Ticket Type")]
        public int TicketTypeId { get; set; }

        [Required]
        [Display(Name = "Session")]
        public int SessionId { get; set; }



        [Required]
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Total Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Booking Reference")]
        public string BookingReference { get; set; } = string.Empty;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Cancelled Date")]
        public DateTime? CancelledDate { get; set; }

        // Legacy fields for backward compatibility
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }

        // Navigation properties
        [ForeignKey("SeatId")]
        public virtual Seat Seat { get; set; } = null!;

        [ForeignKey("TicketTypeId")]
        public virtual TicketType TicketType { get; set; } = null!;

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; } = null!;



        // Helper methods
        public void GenerateBookingReference()
        {
            BookingReference = $"BK{DateTime.Now:yyyyMMdd}{Id:D6}";
        }
    }
}
