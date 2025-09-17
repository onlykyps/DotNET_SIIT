using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmsService _filmService;

        public FilmsController(IFilmsService filmService)
        {
            _filmService = filmService;
        }

        // GET: Films
        public async Task<IActionResult> Index(string searchTerm)
        {
            IEnumerable<Film> Films;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                Films = await _filmService.SearchAsync(searchTerm);
                ViewBag.SearchTerm = searchTerm;
            }
            else
            {
                Films = await _filmService.GetAllAsync();
            }

            return View(Films);
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var Film = await _filmService.GetByIdAsync(id);
            if (Film == null)
            {
                return NotFound();
            }
            return View(Film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Film Film)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _filmService.CreateAsync(Film);
                    TempData["SuccessMessage"] = "Film created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating Film: {ex.Message}");
                }
            }
            return View(Film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var Film = await _filmService.GetByIdAsync(id);
            if (Film == null)
            {
                return NotFound();
            }
            return View(Film);
        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Film Film)
        {
            if (id != Film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _filmService.UpdateAsync(Film);
                    TempData["SuccessMessage"] = "Film updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating Film: {ex.Message}");
                }
            }
            return View(Film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var Film = await _filmService.GetByIdAsync(id);
            if (Film == null)
            {
                return NotFound();
            }
            return View(Film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _filmService.DeleteAsync(id);
                if (success)
                {
                    TempData["SuccessMessage"] = "Film deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Film not found.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting Film: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Films/ToggleStatus/5
        public async Task<IActionResult> ToggleStatus(int id)
        {
            try
            {
                var Film = await _filmService.GetByIdAsync(id);
                if (Film == null)
                {
                    TempData["ErrorMessage"] = "Film not found.";
                    return RedirectToAction(nameof(Index));
                }

                Film.IsActive = !Film.IsActive;
                await _filmService.UpdateAsync(Film);

                TempData["SuccessMessage"] = $"Film {(Film.IsActive ? "activated" : "deactivated")} successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating Film status: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // API endpoint for getting active Films (for AJAX calls)
        [HttpGet]
        public async Task<IActionResult> GetActivefilms()
        {
            try
            {
                var Films = await _filmService.GetActiveFilmsAsync();
                return Json(Films.Select(m => new {
                    id = m.Id,
                    title = m.Title,
                    duration = m.DurationMinutes,
                    genre = m.Genre,
                    rating = m.Rating
                }));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}