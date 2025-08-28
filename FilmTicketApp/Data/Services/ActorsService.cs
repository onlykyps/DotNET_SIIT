using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilmTicketApp.Data.Services
{
   public class ActorsService : IActorsService
   {
      private readonly AppDBContext _dbContext;

      public ActorsService(AppDBContext dbContext)
      {
            _dbContext = dbContext;
      }

      public async Task Add(Actor actor)
      {
         await _dbContext.Actors.AddAsync(actor);
         await _dbContext.SaveChangesAsync();
      }

      public async Task Delete(int id)
      {
         var result = await _dbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);

         _dbContext.Actors.Remove(result);
         await _dbContext.SaveChangesAsync();
      }

      public async Task<Actor> Update(int id, Actor newActor)
      {
         _dbContext.Update(newActor);
         await _dbContext.SaveChangesAsync();

         return newActor;
      }
   }
}
