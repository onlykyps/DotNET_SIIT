using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public class ProducersService : EntityBaseRepo<Producer>, IProducersService
   {
      public ProducersService(AppDBContext dbContext) : base(dbContext)
      {
      }
   }
}
