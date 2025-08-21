using FilmTicketApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
         var data = _dbContext.Films.Include(x => x.Cinema)
                                    .OrderBy(x => x.Name)
                                    .ToList();
         return View(data);
      }
   }
}
