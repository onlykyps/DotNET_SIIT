using FilmTicketApp.Models;
using System;
using System.Linq.Expressions;

namespace FilmTicketApp.Data.Base
{
   public interface IEntityBaseRepo<T> where T : class, IEntityBase, new()
   {
      Task<IEnumerable<T>> GetAll();

      Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expr);
      Task<T> GetById(int id);
      Task Add(T entity);
      Task Update(int id, T entity);
      Task Delete(int id);

   }
}
