
using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FilmTicketApp.Data.Base
{
   public class EntityBaseRepo<T> : IEntityBaseRepo<T> where T : class, IEntityBase, new()
   {
      private readonly AppDBContext _dbContext;

      public EntityBaseRepo(AppDBContext dbContext)
      {
         _dbContext = dbContext;
      }

      public async Task Add(T entity)
      {
         await _dbContext.Set<T>().AddAsync(entity);
         await _dbContext.SaveChangesAsync();
      }

      public async Task Delete(int id)
      {
         var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

         EntityEntry entityEntry = _dbContext.Entry<T>(entity);

         entityEntry.State = EntityState.Deleted;

         await _dbContext.SaveChangesAsync();
      }

      public async Task<IEnumerable<T>> GetAll()
      {
         var result = await _dbContext.Set<T>().ToListAsync();
         return result;
      }

      public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] expr)
      {
         IQueryable<T> query = _dbContext.Set<T>();
         query = expr.Aggregate(query, (current, expr) => current.Include(expr));

         return await query.ToListAsync();
      }

      public async Task<T> GetById(int id)
      {
         var results = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

         return results;
      }

      public async Task Update(int id, T entity)
      {
         EntityEntry entityEntry = _dbContext.Entry<T>(entity);

         entityEntry.State = EntityState.Modified;

         await _dbContext.SaveChangesAsync();

      }

      //public async Task<IEnumerable<Actor>> GetActors()
      //{
        
      //}

      //public async Task<Actor> GetById(int id)
      //{
        
      //}
   }
}
