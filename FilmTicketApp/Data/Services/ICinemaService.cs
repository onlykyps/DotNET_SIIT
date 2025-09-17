using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema?> GetByIdAsync(int id);
        Task<Cinema> CreateAsync(Cinema cinema);
        Task<Cinema> UpdateAsync(Cinema cinema);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Cinema>> SearchAsync(string searchTerm);
        Task<int> GetSeatCountAsync(int cinemaId);
    }
}