using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
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

      public async Task<IActionResult> Create()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
      {
         if (!ModelState.IsValid)
         {
            return View(cinema);
         }

         await _cinemasService.Add(cinema);

         return RedirectToAction(nameof(Index));
      }

   }
}
