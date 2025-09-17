using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public class CinemasService:EntityBaseRepo<Cinema>, ICinemasService
   {
      public CinemasService(AppDBContext appDBContext): base(appDBContext)
      {
         
      }

        public Task<Cinema> CreateAsync(Cinema cinema)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cinema> UpdateAsync(Cinema cinema)
        {
            throw new NotImplementedException();
        }
    }
}
