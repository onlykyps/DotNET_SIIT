using FilmTicketApp.Data.Base;
using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
   public class CinemasService:EntityBaseRepo<Cinema>, ICinemasService
   {
      public CinemasService(AppDBContext appDBContext): base(appDBContext)
      {
         
      }

   }
}
