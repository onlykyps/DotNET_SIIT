using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllCinemasAsync();
        Task<Cinema?> GetCinemaByIdAsync(int id);
        Task<Cinema> CreateCinemaAsync(Cinema cinema);
        Task<Cinema> UpdateCinemaAsync(Cinema cinema);
        Task<bool> DeleteCinemaAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Cinema>> SearchAsync(string searchTerm);
        Task<int> GetSeatCountAsync(int cinemaId);
    }
}
