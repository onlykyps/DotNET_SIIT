using FilmTicketApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class ProducersController : Controller
   {
      private readonly AppDBContext _dbContext;

      public ProducersController(AppDBContext dbContext)
      {
         _dbContext = dbContext;
      }

      public IActionResult Index()
      {
         var data = _dbContext.Producers.ToList();
         return View(data);
      }
   }
}
