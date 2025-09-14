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
            if (ModelState.IsValid)
            {
                try
                {
                    await _cinemasService.CreateAsync(cinema);
                    TempData["SuccessMessage"] = "Cinema created successfully with 400 seats (20x20 layout)!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating cinema: {ex.Message}");
                }
            }
            return View(cinema);
        }

        public async Task<IActionResult> Details(int id)
      {
         var cinemaDetails = await _cinemasService.GetById(id);

         if (cinemaDetails == null)
         {
            return View("NotFound");
         }

         return View(cinemaDetails);
      }

      public IActionResult Edit(int id)
      {
         Cinema cinemaDetails = _cinemasService.GetById(id).Result;

         if (cinemaDetails == null)
         {
            return View("Details");
         }
         else
         {
            return View(cinemaDetails);
         }
      }

      [HttpPost]
      public async Task<IActionResult> Edit(int id, [Bind("Logo,Name,Description")] Cinema cinema)
      {
         if (!ModelState.IsValid)
         {
            return View(cinema);
         }

         if(cinema.Id == id)
            await _cinemasService.Update(id, cinema);
         else
         {
            cinema.Id = id;
            await _cinemasService.Update(id, cinema);
         }

            return RedirectToAction(nameof(Index));
      }

      public async Task<IActionResult> Delete(int id)
      {
         var details = await _cinemasService.GetById(id);

         if (details == null)
         {
            return View("NotFound");
         }

         return View(details);
      }

      [HttpPost, ActionName("Delete")]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         Cinema producerDetails = _cinemasService.GetById(id).Result;
         if (producerDetails == null)
            return View(this);

         await _cinemasService.Delete(id);

         return RedirectToAction(nameof(Index));
      }

   }
}
