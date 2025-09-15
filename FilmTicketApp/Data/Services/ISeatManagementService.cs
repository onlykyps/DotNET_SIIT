using FilmTicketApp.Models;
using FilmTicketApp.Data.ViewModels;

namespace FilmTicketApp.Data.Services
{
    public interface ISeatManagementService
    {
        Task<List<Seat>> GetAllSeatsAsync();
        Task<List<TicketType>> GetTicketTypesAsync();
        Task<bool> ReserveSeatsAsync(int numberOfTickets, int row, int firstSeat, int ticketTypeId, int sessionId);
        Task<decimal> ReturnTicketsAsync(int row, int numberOfTickets, int firstSeat);
        Task<List<TicketReservation>> GetReservationsAsync();
        Task<bool> UpdateTicketPricesAsync(Dictionary<int, decimal> ticketTypePrices);
        Task InitializeTheaterSeatsAsync();
        Task<SeatAvailabilityViewModel> GetSeatAvailabilityAsync();
        Task<Seat?> GetByIdAsync(int seatId);
        Task<List<Session>> GetActiveSessionsAsync();
    }
}