using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Base
{
   public interface IEntityBaseRepo<T> where T : class, IEntityBase, new()
   {
      Task<IEnumerable<T>> GetAll();
      Task<T> GetById(int id);
      Task Add(T entity);
      Task Update(int id, T entity);
      Task Delete(int id);

   }
}
