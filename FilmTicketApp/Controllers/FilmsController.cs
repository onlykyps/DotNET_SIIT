using FilmTicketApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class FilmsController : Controller
   {
      private readonly AppDBContext _dbContext;

      public FilmsController(AppDBContext dbContext)
      {
         _dbContext = dbContext;
      }
      public IActionResult Index()
      {
         var data = _dbContext.Films.ToList();
         return View(data);
      }
   }
}
