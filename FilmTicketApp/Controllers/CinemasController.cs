using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        // GET: Cinemas
        public async Task<IActionResult> Index(string searchTerm)
        {
            IEnumerable<Cinema> cinemas;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                cinemas = await _cinemaService.SearchAsync(searchTerm);
                ViewBag.SearchTerm = searchTerm;
            }
            else
            {
                cinemas = await _cinemaService.GetAllAsync();
            }

            return View(cinemas);
        }

        // GET: Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            ViewBag.SeatCount = await _cinemaService.GetSeatCountAsync(id);
            return View(cinema);
        }

        // GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _cinemaService.CreateAsync(cinema);
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

        // GET: Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }

        // POST: Cinemas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (id != cinema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cinemaService.UpdateAsync(cinema);
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

        // GET: Cinemas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            ViewBag.SeatCount = await _cinemaService.GetSeatCountAsync(id);
            return View(cinema);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _cinemaService.DeleteAsync(id);
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

        // API endpoint for getting all cinemas (for AJAX calls)
        [HttpGet]
        public async Task<IActionResult> GetAllCinemas()
        {
            try
            {
                var cinemas = await _cinemaService.GetAllAsync();
                return Json(cinemas.Select(c => new {
                    id = c.Id,
                    name = c.Name,
                    description = c.Description,
                    logo = c.Logo
                }));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: Cinemas/SeatLayout/5
        public async Task<IActionResult> SeatLayout(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            ViewBag.SeatCount = await _cinemaService.GetSeatCountAsync(id);
            return View(cinema);
        }
    }
}