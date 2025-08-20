using FilmTicketApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class ActorsController : Controller
   {
      private readonly AppDBContext _dbContext;

      public ActorsController(AppDBContext dbContext)
      {
         _dbContext = dbContext;
      }

      public IActionResult Index()
      {
         var data = _dbContext.Actors.ToList();
         return View(data);
      }
   }
}
