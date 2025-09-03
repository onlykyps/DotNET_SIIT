using FilmTicketApp.Data.Base;
using FilmTicketApp.Data.ViewModels;
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

      public async Task<NewFilmDropdownsVM> GetNewFilmDropdownsValues()
      {
         var response = new NewFilmDropdownsVM();

         response.Actors = await _dbContext.Actors.OrderBy(a => a.FullName).ToListAsync();
         response.Cinemas = await _dbContext.Cinemas.OrderBy(a => a.Name).ToListAsync();
         response.Producers = await _dbContext.Producers.OrderBy(a => a.FullName).ToListAsync();

         return response;
      }
   }
}
