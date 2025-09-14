using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public interface ICinemasService: IEntityBaseRepo<Cinema>
   {
        Task<Cinema> CreateAsync(Cinema cinema);
    }
}
