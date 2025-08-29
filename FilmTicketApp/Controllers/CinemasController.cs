using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class CinemasController : Controller
   {
      private readonly ICinemasService _cinemasService;

      public CinemasController(ICinemasService cinemasService)
      {
         _cinemasService = cinemasService;
      }
      public async Task<IActionResult> Index()
      {
         var data = await _cinemasService.GetAll();
         return View(data);
      }
   }
}
