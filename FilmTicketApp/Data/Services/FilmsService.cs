using FilmTicketApp.Data.Base;
using FilmTicketApp.Data.ViewModels;
using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmTicketApp.Data.Services
{
    public class FilmService : IFilmsService
    {
        private readonly AppDBContext _context;

        public FilmService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _context.Films
                .Include(m => m.Sessions)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        public async Task<Film?> GetByIdAsync(int id)
        {
            return await _context.Films
                .Include(m => m.Sessions)
                .ThenInclude(s => s.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Film> CreateAsync(Film Film)
        {
            if (Film == null)
                throw new ArgumentNullException(nameof(Film));

            Film.Id = 0; // Ensure new entity
            _context.Films.Add(Film);
            await _context.SaveChangesAsync();
            return Film;
        }

        public async Task<Film> UpdateAsync(Film Film)
        {
            if (Film == null)
                throw new ArgumentNullException(nameof(Film));

            var existingFilm = await _context.Films.FindAsync(Film.Id);
            if (existingFilm == null)
                throw new InvalidOperationException($"Film with ID {Film.Id} not found.");

            // Update properties
            existingFilm.Title = Film.Title;
            existingFilm.Description = Film.Description;
            existingFilm.DurationMinutes = Film.DurationMinutes;
            existingFilm.Genre = Film.Genre;
            existingFilm.Rating = Film.Rating;
            existingFilm.ReleaseDate = Film.ReleaseDate;
            existingFilm.PosterImageUrl = Film.PosterImageUrl;
            existingFilm.IsActive = Film.IsActive;

            await _context.SaveChangesAsync();
            return existingFilm;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Film = await _context.Films.FindAsync(id);
            if (Film == null)
                return false;

            // Check if Film has active sessions
            var hasActiveSessions = await _context.Sessions
                .AnyAsync(s => s.FilmId == id && s.IsActive);

            if (hasActiveSessions)
            {
                // Soft delete - mark as inactive
                Film.IsActive = false;
                await _context.SaveChangesAsync();
            }
            else
            {
                // Hard delete if no active sessions
                _context.Films.Remove(Film);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<IEnumerable<Film>> GetActiveFilmsAsync()
        {
            return await _context.Films
                .Where(m => m.IsActive)
                .Include(m => m.Sessions.Where(s => s.IsActive))
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Films.AnyAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Film>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync();

            searchTerm = searchTerm.ToLower();
            return await _context.Films
                .Where(m => m.Title.ToLower().Contains(searchTerm) ||
                           m.Description.ToLower().Contains(searchTerm) ||
                           m.Genre.ToLower().Contains(searchTerm))
                .Include(m => m.Sessions)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }
    }
}
