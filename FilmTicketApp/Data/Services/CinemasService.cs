using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly AppDBContext _context;

        public CinemaService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Cinema?> GetByIdAsync(int id)
        {
            return await _context.Cinemas
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cinema> CreateAsync(Cinema cinema)
        {
            if (cinema == null)
                throw new ArgumentNullException(nameof(cinema));

            cinema.Id = 0; // Ensure new entity
            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();

            // Initialize seats for the new cinema
            await InitializeCinemaSeatsAsync(cinema.Id);

            return cinema;
        }

        public async Task<Cinema> UpdateAsync(Cinema cinema)
        {
            if (cinema == null)
                throw new ArgumentNullException(nameof(cinema));

            var existingCinema = await _context.Cinemas.FindAsync(cinema.Id);
            if (existingCinema == null)
                throw new InvalidOperationException($"Cinema with ID {cinema.Id} not found.");

            // Update properties
            existingCinema.Name = cinema.Name;
            existingCinema.Description = cinema.Description;
            existingCinema.Logo = cinema.Logo;

            await _context.SaveChangesAsync();
            return existingCinema;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null)
                return false;

            // Check if cinema has active sessions
            var hasActiveSessions = await _context.Sessions
                .AnyAsync(s => s.CinemaId == id && s.IsActive);

            if (hasActiveSessions)
            {
                throw new InvalidOperationException("Cannot delete cinema with active sessions. Please deactivate or remove all sessions first.");
            }

            // Remove associated seats first
            var seats = await _context.Seats.Where(s => s.CinemaId == id).ToListAsync();
            _context.Seats.RemoveRange(seats);

            // Remove cinema
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Cinemas.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cinema>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync();

            searchTerm = searchTerm.ToLower();
            return await _context.Cinemas
                .Where(c => c.Name.ToLower().Contains(searchTerm) ||
                           c.Description.ToLower().Contains(searchTerm))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<int> GetSeatCountAsync(int cinemaId)
        {
            return await _context.Seats
                .CountAsync(s => s.CinemaId == cinemaId);
        }

        private async Task InitializeCinemaSeatsAsync(int cinemaId)
        {
            // Create seats for the cinema (20 rows, 20 seats per row)
            var seats = new List<Seat>();
            for (int row = 1; row <= 20; row++)
            {
                for (int seatNumber = 1; seatNumber <= 20; seatNumber++)
                {
                    seats.Add(new Seat
                    {
                        Row = row,
                        SeatNumber = seatNumber,
                        CinemaId = cinemaId,
                        IsOccupied = false,
                        CreatedDate = DateTime.Now
                    });
                }
            }

            _context.Seats.AddRange(seats);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Cinema>> GetAllCinemasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cinema?> GetCinemaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> CreateCinemaAsync(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> UpdateCinemaAsync(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCinemaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}