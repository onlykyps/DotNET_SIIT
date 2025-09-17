using FilmTicketApp.Data.Base;
using FilmTicketApp.Data;
using FilmTicketApp.Models;
using FilmTicketApp.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data.Services
{
    public class SeatManagementService : ISeatManagementService
    {
        private readonly AppDBContext _context;
        private readonly IPriceNotificationService _priceNotificationService;

        public SeatManagementService(AppDBContext context, IPriceNotificationService priceNotificationService)
        {
            _context = context;
            _priceNotificationService = priceNotificationService;
        }

        public async Task<List<Seat>> GetAllSeatsAsync()
        {
            return await _context.Seats
                .Include(s => s.Reservations)
                .OrderBy(s => s.Row)
                .ThenBy(s => s.SeatNumber)
                .ToListAsync();
        }

        public async Task<List<TicketType>> GetTicketTypesAsync()
        {
            return await _context.TicketTypes.ToListAsync();
        }

        public async Task<List<Session>> GetActiveSessionsAsync()
        {
            var currentDateTime = DateTime.Now;
            var sessions = await _context.Sessions
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .ToListAsync();
            
            return sessions
                .Where(s => s.SessionDate.Add(s.StartTime) > currentDateTime)
                .OrderBy(s => s.SessionDate.Add(s.StartTime))
                .ToList();
        }

        public async Task<bool> ReserveSeatsAsync(int numberOfTickets, int row, int firstSeat, int ticketTypeId, int sessionId)
        {
            try
            {
                var ticketType = await _context.TicketTypes.FindAsync(ticketTypeId);
                if (ticketType == null) return false;

                var session = await _context.Sessions.FindAsync(sessionId);
                if (session == null) return false;

                var reservations = new List<TicketReservation>();

                for (int i = 0; i < numberOfTickets; i++)
                {
                    var seatNumber = firstSeat + i;
                    var seat = await _context.Seats
                        .FirstOrDefaultAsync(s => s.Row == row && s.SeatNumber == seatNumber);

                    if (seat == null)
                    {
                        return false; 
                    }
                    
                    var existingReservation = await _context.TicketReservations
                        .AnyAsync(tr => tr.SeatId == seat.Id && tr.SessionId == sessionId && tr.IsActive);
                    
                    if (existingReservation)
                    {
                        return false; 
                    }

                    var reservation = new TicketReservation
                    {
                        SeatId = seat.Id,
                        TicketTypeId = ticketTypeId,
                        SessionId = sessionId,
                        TotalAmount = ticketType.Price,
                        ReservationDate = DateTime.Now,
                        IsActive = true
                    };

                    reservations.Add(reservation);
                }

                _context.TicketReservations.AddRange(reservations);
                await _context.SaveChangesAsync();

                foreach (var reservation in reservations)
                {
                    reservation.GenerateBookingReference();
                }
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<decimal> ReturnTicketsAsync(int row, int numberOfTickets, int firstSeat)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var reservationsToReturn = new List<TicketReservation>();
                decimal totalRefund = 0;

                for (int i = 0; i < numberOfTickets; i++)
                {
                    int seatNumber = firstSeat + i;
                    if (seatNumber > 20) break;

                    var reservation = await _context.TicketReservations
                        .Include(r => r.Seat)
                        .Include(r => r.TicketType)
                        .FirstOrDefaultAsync(r => r.Seat.Row == row && r.Seat.SeatNumber == seatNumber);

                    if (reservation != null)
                    {
                        reservationsToReturn.Add(reservation);
                        totalRefund += reservation.TotalAmount;
                    }
                }

                if (reservationsToReturn.Count == 0)
                {
                    await transaction.RollbackAsync();
                    return 0;
                }

                foreach (var reservation in reservationsToReturn)
                {
                    reservation.Seat.IsOccupied = false;
                    _context.TicketReservations.Remove(reservation);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return totalRefund;
            }
            catch
            {
                await transaction.RollbackAsync();
                return 0;
            }
        }

        public async Task<List<TicketReservation>> GetReservationsAsync()
        {
            return await _context.TicketReservations
                .Include(r => r.Seat)
                .Include(r => r.TicketType)
                .OrderBy(r => r.ReservationDate)
                .ToListAsync();
        }

        public async Task<bool> UpdateTicketPricesAsync(Dictionary<int, decimal> ticketTypePrices)
        {
            try
            {
                var updatedTicketTypes = new List<TicketType>();
                
                foreach (var kvp in ticketTypePrices)
                {
                    var ticketType = await _context.TicketTypes.FindAsync(kvp.Key);
                    if (ticketType != null && kvp.Value > 0)
                    {
                        ticketType.Price = kvp.Value;
                        updatedTicketTypes.Add(ticketType);
                    }
                }

                await _context.SaveChangesAsync();
                
                if (updatedTicketTypes.Any())
                {
                    await _priceNotificationService.NotifyPriceUpdateAsync(updatedTicketTypes);
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task InitializeTheaterSeatsAsync()
        {
            var existingSeats = await _context.Seats.CountAsync();
            if (existingSeats > 0) return;

            var cinemas = await _context.Cinemas.ToListAsync();
            var seats = new List<Seat>();
            
            foreach (var cinema in cinemas)
            {
                for (int row = 1; row <= 20; row++)
                {
                    for (int seatNumber = 1; seatNumber <= 20; seatNumber++)
                    {
                        seats.Add(new Seat
                        {
                            Row = row,
                            SeatNumber = seatNumber,
                            IsOccupied = false,
                            CinemaId = cinema.Id,
                            CreatedDate = DateTime.Now
                        });
                    }
                }
            }

            _context.Seats.AddRange(seats);
            await _context.SaveChangesAsync();
        }

        public async Task<SeatAvailabilityViewModel> GetSeatAvailabilityAsync()
        {
            var seats = await GetAllSeatsAsync();
            var ticketTypes = await GetTicketTypesAsync();

            var seatGrid = new List<List<Seat>>();
            for (int row = 1; row <= 20; row++)
            {
                var rowSeats = seats.Where(s => s.Row == row).OrderBy(s => s.SeatNumber).ToList();
                seatGrid.Add(rowSeats);
            }

            var occupiedSeats = await _context.TicketReservations
                .Where(tr => tr.IsActive)
                .Select(tr => tr.SeatId)
                .Distinct()
                .CountAsync();

            return new SeatAvailabilityViewModel
            {
                SeatGrid = seatGrid,
                TotalSeats = seats.Count,
                AvailableSeats = seats.Count - occupiedSeats,
                OccupiedSeats = occupiedSeats,
                TicketTypes = ticketTypes
            };
        }

        public async Task<Seat?> GetByIdAsync(int seatId)
        {
            return await _context.Seats
                .Include(s => s.Reservations)
                .FirstOrDefaultAsync(s => s.Id == seatId);
        }
    }
}