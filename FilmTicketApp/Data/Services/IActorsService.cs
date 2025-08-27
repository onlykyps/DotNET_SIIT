using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public interface IActorsService
   {
      Task<IEnumerable<Actor>> GetActors();
      Task<Actor> GetById(int id);
      Task Add(Actor actor);
      Task<Actor> Update(int id, Actor newActor);
      Task Delete(int id);
   }
}
