using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public interface IFilmsService: IEntityBaseRepo<Film>
   {
      Task<Film> GetFilmById(int id);
   }
}
