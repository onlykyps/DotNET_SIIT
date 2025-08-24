using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class ActorsController : Controller
   {
      private readonly IActorsService _service;

      public ActorsController(IActorsService service)
      {
         _service = service;
      }

      public async Task<IActionResult> Index()
      {
         var data = await _service.GetActors();
         return View(data);
      }

      
   }
}
