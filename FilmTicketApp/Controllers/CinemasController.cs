using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemasService;

        public CinemasController(ICinemaService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _cinemasService.GetAllAsync();
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
            var cinemaDetails = await _cinemasService.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);
        }

        public IActionResult Edit(int id)
        {
            Cinema cinemaDetails = _cinemasService.GetCinemaByIdAsync(id).Result;

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
            if (id != cinema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cinemasService.UpdateAsync(cinema);
                    TempData["SuccessMessage"] = "Cinema updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating cinema: {ex.Message}");
                }
            }
            return View(cinema);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _cinemasService.GetByIdAsync(id);

            if (details == null)
            {
                return View("NotFound");
            }

            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _cinemasService.DeleteCinemaAsync(id);
                if (success)
                {
                    TempData["SuccessMessage"] = "Cinema and all associated seats deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Cinema not found.";
                }
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting cinema: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
