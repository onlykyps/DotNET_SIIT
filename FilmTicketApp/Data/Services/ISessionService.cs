using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(int id);
        Task<Session> CreateAsync(Session session);
        Task<Session> UpdateAsync(Session session);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Session>> GetActiveSessionsAsync();
        Task<IEnumerable<Session>> GetSessionsByFilmAsync(int movieId);
        Task<IEnumerable<Session>> GetSessionsByCinemaAsync(int cinemaId);
        Task<IEnumerable<Session>> GetSessionsByDateAsync(DateTime date);
        Task<bool> ExistsAsync(int id);
        Task<bool> HasConflictingSessionAsync(int cinemaId, DateTime sessionDate, TimeSpan startTime, TimeSpan endTime, int? excludeSessionId = null);
        Task<IEnumerable<Session>> GetUpcomingSessionsAsync();
    }
}