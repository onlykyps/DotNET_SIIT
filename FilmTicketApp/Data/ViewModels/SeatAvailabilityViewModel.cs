using FilmTicketApp.Models;

namespace FilmTicketApp.Data.ViewModels
{
    public class SeatAvailabilityViewModel
    {
        public List<List<Seat>> SeatGrid { get; set; } = new List<List<Seat>>();
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int OccupiedSeats { get; set; }
        public List<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public const int MaxRows = 20;
        public const int MaxSeatsPerRow = 20;
    }

    public class SeatReservationViewModel
    {
        public int NumberOfTickets { get; set; }
        public int Row { get; set; }
        public int FirstSeat { get; set; }
        public int TicketTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public List<List<Seat>> SeatGrid { get; set; } = new List<List<Seat>>();
    }

    public class TicketReturnViewModel
    {
        public int Row { get; set; }
        public int NumberOfTickets { get; set; }
        public int FirstSeat { get; set; }
        public decimal RefundAmount { get; set; }
    }
}