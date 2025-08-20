using FilmTicketApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class CinemasController : Controller
   {
      private readonly AppDBContext _dbContext;

      public CinemasController(AppDBContext dbContext)
      {
         _dbContext = dbContext;
      }
      public IActionResult Index()
      {
         var data = _dbContext.Cinemas.ToList();
         return View(data);
      }
   }
}
