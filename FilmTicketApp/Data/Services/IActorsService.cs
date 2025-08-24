using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public interface IActorsService
   {
      Task<IEnumerable<Actor>> GetActors();
      Actor GetById(int id);
      void Add(Actor actor);
      Actor Update(int id, Actor newActor);
      void Delete(int id);
   }
}
