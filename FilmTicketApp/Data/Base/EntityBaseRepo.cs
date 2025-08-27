
namespace FilmTicketApp.Data.Base
{
   public class EntityBaseRepo<T> : IEntityBaseRepo<T> where T : class, IEntityBase, new()
   {
      public Task Add(T entity)
      {
         throw new NotImplementedException();
      }

      public Task Delete(int id)
      {
         throw new NotImplementedException();
      }

      public Task<IEnumerable<T>> GetAll()
      {
         throw new NotImplementedException();
      }

      public Task<T> GetById(int id)
      {
         throw new NotImplementedException();
      }

      public Task<T> Update(int id, T entity)
      {
         throw new NotImplementedException();
      }
   }
}
