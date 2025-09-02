using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public class FilmsService : EntityBaseRepo<Film>, IFilmsService
   {
      public FilmsService(AppDBContext dbContext) : base(dbContext)
      {
      }
   }
}
