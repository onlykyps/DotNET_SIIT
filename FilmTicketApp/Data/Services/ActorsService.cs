using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data.Services
{
   public class ActorsService : IActorsService
   {
      private readonly AppDBContext _dbContext;

      public ActorsService(AppDBContext dbContext)
      {
            _dbContext = dbContext;
      }

      void IActorsService.Add(Actor actor)
      {
         throw new NotImplementedException();
      }

      void IActorsService.Delete(int id)
      {
         throw new NotImplementedException();
      }

      public async Task<IEnumerable<Actor>> GetActors()
      {
         var result = await _dbContext.Actors.ToListAsync();
         return result;
      }

      Actor IActorsService.GetById(int id)
      {
         throw new NotImplementedException();
      }

      Actor IActorsService.Update(int id, Actor newActor)
      {
         throw new NotImplementedException();
      }
   }
}
