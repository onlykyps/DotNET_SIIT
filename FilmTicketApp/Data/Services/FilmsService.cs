using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmTicketApp.Data.Services
{
   public class FilmsService : EntityBaseRepo<Film>, IFilmsService
   {
      private readonly AppDBContext _dbContext;

      public FilmsService(AppDBContext dbContext) : base(dbContext)
      {
         _dbContext = dbContext;
      }

      public async Task<Film> GetFilmById(int id)
      {
         var filmDetails = await _dbContext.Films.Include(f => f.Cinema)
                                             .Include(p => p.Producer)
                                             .Include(fa => fa.FilmActors)
                                             .ThenInclude(a => a.Actor)
                                             .FirstOrDefaultAsync(x => x.Id == id);

         return filmDetails;
      }
   }
}
