using FilmTicketApp.Data.Base;
using FilmTicketApp.Data.ViewModels;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public interface IFilmsService : IEntityBaseRepo<Film>
    {
        Task<Film> GetFilmById(int id);
        Task<NewFilmDropdownsVM> GetNewFilmDropdownsValues();
        Task<bool> Delete(int id);
    }
}
