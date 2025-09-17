using FilmTicketApp.Data.Base;
using FilmTicketApp.Data.ViewModels;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public interface IFilmsService
    {
        Task<IEnumerable<Film>> GetAllAsync();
        Task<Film?> GetByIdAsync(int id);
        Task<Film> CreateAsync(Film Film);
        Task<Film> UpdateAsync(Film Film);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Film>> GetActiveFilmsAsync();
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Film>> SearchAsync(string searchTerm);
    }
}
