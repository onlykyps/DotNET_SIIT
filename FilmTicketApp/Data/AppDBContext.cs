using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Data
{
   public class AppDBContext: DbContext
   {
      public AppDBContext(DbContextOptions<AppDBContext> dbContextOp): base(dbContextOp)
      {
         
      }

   }
}
