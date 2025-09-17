using FilmTicketApp.Data;
using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data.Services
{
    public class SessionService : ISessionService
    {
        private readonly AppDBContext _context;

        public SessionService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            return await _context.Sessions
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .Include(s => s.TicketReservations)
                .OrderBy(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            return await _context.Sessions
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .Include(s => s.TicketReservations)
                .ThenInclude(tr => tr.Seat)
                .Include(s => s.TicketReservations)
                .ThenInclude(tr => tr.TicketType)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Session> CreateAsync(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            // Validate Film and cinema exist
            var FilmExists = await _context.Films.AnyAsync(m => m.Id == session.FilmId);
            var cinemaExists = await _context.Cinemas.AnyAsync(c => c.Id == session.CinemaId);

            if (!FilmExists)
                throw new InvalidOperationException($"Film with ID {session.FilmId} not found.");
            if (!cinemaExists)
                throw new InvalidOperationException($"Cinema with ID {session.CinemaId} not found.");

            // Check for conflicting sessions
            var hasConflict = await HasConflictingSessionAsync(
                session.CinemaId,
                session.SessionDate,
                session.StartTime,
                session.EndTime);

            if (hasConflict)
                throw new InvalidOperationException("A session already exists at this time in the selected cinema.");

            session.Id = 0; // Ensure new entity
            session.CreatedDate = DateTime.Now;
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<Session> UpdateAsync(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var existingSession = await _context.Sessions.FindAsync(session.Id);
            if (existingSession == null)
                throw new InvalidOperationException($"Session with ID {session.Id} not found.");

            // Validate Film and cinema exist
            var FilmExists = await _context.Films.AnyAsync(m => m.Id == session.FilmId);
            var cinemaExists = await _context.Cinemas.AnyAsync(c => c.Id == session.CinemaId);

            if (!FilmExists)
                throw new InvalidOperationException($"Film with ID {session.FilmId} not found.");
            if (!cinemaExists)
                throw new InvalidOperationException($"Cinema with ID {session.CinemaId} not found.");

            // Check for conflicting sessions (excluding current session)
            var hasConflict = await HasConflictingSessionAsync(
                session.CinemaId,
                session.SessionDate,
                session.StartTime,
                session.EndTime,
                session.Id);

            if (hasConflict)
                throw new InvalidOperationException("A session already exists at this time in the selected cinema.");

            // Update properties
            existingSession.SessionDate = session.SessionDate;
            existingSession.StartTime = session.StartTime;
            existingSession.EndTime = session.EndTime;
            existingSession.FilmId = session.FilmId;
            existingSession.CinemaId = session.CinemaId;
            existingSession.IsActive = session.IsActive;

            await _context.SaveChangesAsync();
            return existingSession;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
                return false;

            // Check if session has active reservations
            var hasActiveReservations = await _context.TicketReservations
                .AnyAsync(tr => tr.SessionId == id && tr.IsActive);

            if (hasActiveReservations)
            {
                // Soft delete - mark as inactive
                session.IsActive = false;
                await _context.SaveChangesAsync();
            }
            else
            {
                // Hard delete if no active reservations
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<IEnumerable<Session>> GetActiveSessionsAsync()
        {
            return await _context.Sessions
                .Where(s => s.IsActive)
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .OrderBy(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByFilmAsync(int FilmId)
        {
            return await _context.Sessions
                .Where(s => s.FilmId == FilmId && s.IsActive)
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .OrderBy(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByCinemaAsync(int cinemaId)
        {
            return await _context.Sessions
                .Where(s => s.CinemaId == cinemaId && s.IsActive)
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .OrderBy(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByDateAsync(DateTime date)
        {
            return await _context.Sessions
                .Where(s => s.SessionDate.Date == date.Date && s.IsActive)
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .OrderBy(s => s.StartTime)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Sessions.AnyAsync(s => s.Id == id);
        }

        public async Task<bool> HasConflictingSessionAsync(int cinemaId, DateTime sessionDate, TimeSpan startTime, TimeSpan endTime, int? excludeSessionId = null)
        {
            var query = _context.Sessions
                .Where(s => s.CinemaId == cinemaId &&
                           s.SessionDate.Date == sessionDate.Date &&
                           s.IsActive &&
                           ((s.StartTime < endTime && s.EndTime > startTime)));

            if (excludeSessionId.HasValue)
            {
                query = query.Where(s => s.Id != excludeSessionId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Session>> GetUpcomingSessionsAsync()
        {
            var now = DateTime.Now;
            return await _context.Sessions
                .Where(s => s.IsActive &&
                           (s.SessionDate.Date > now.Date ||
                            (s.SessionDate.Date == now.Date && s.StartTime > now.TimeOfDay)))
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .OrderBy(s => s.SessionDate)
                .ThenBy(s => s.StartTime)
                .ToListAsync();
        }
    }
}