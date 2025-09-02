using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Controllers
{
   public class FilmsController : Controller
   {
      private readonly IFilmsService _filmsService;

      public FilmsController(IFilmsService filmsService)
      {
         _filmsService = filmsService;
      }
      public async Task<IActionResult> Index()
      {
         var data = await _filmsService.GetAll(n => n.Cinema);
         return View(data);
      }
   }
}
