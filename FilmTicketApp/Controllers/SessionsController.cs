using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilmTicketApp.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IFilmsService _filmService;
        private readonly ICinemaService _cinemaService;

        public SessionsController(
            ISessionService sessionService,
            IFilmsService filmService,
            ICinemaService cinemaService)
        {
            _sessionService = sessionService;
            _filmService = filmService;
            _cinemaService = cinemaService;
        }

        // GET: Sessions
        public async Task<IActionResult> Index(DateTime? date, int? filmId, int? cinemaId)
        {
            IEnumerable<Session> sessions;
            
            if (date.HasValue)
            {
                sessions = await _sessionService.GetSessionsByDateAsync(date.Value);
                ViewBag.SelectedDate = date.Value.ToString("yyyy-MM-dd");
            }
            else if (filmId.HasValue)
            {
                sessions = await _sessionService.GetSessionsByFilmAsync(filmId.Value);
                ViewBag.SelectedfilmId = filmId.Value;
            }
            else if (cinemaId.HasValue)
            {
                sessions = await _sessionService.GetSessionsByCinemaAsync(cinemaId.Value);
                ViewBag.SelectedCinemaId = cinemaId.Value;
            }
            else
            {
                sessions = await _sessionService.GetAllAsync();
            }
            
            // Populate filter dropdowns
            ViewBag.films = new SelectList(await _filmService.GetActiveFilmsAsync(), "Id", "Title");
            ViewBag.Cinemas = new SelectList(await _cinemaService.GetAllAsync(), "Id", "Name");
            
            return View(sessions);
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var session = await _sessionService.GetByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // GET: Sessions/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdownsAsync();
            
            // Set default values
            var model = new Session
            {
                SessionDate = DateTime.Today.AddDays(1),
                StartTime = new TimeSpan(19, 0, 0), // 7:00 PM
                EndTime = new TimeSpan(21, 30, 0),  // 9:30 PM
                IsActive = true
            };
            
            return View(model);
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Session session)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Validate session times
                    if (session.StartTime >= session.EndTime)
                    {
                        ModelState.AddModelError("EndTime", "End time must be after start time.");
                        await PopulateDropdownsAsync();
                        return View(session);
                    }

                    // Validate session date
                    if (session.SessionDate.Date < DateTime.Today)
                    {
                        ModelState.AddModelError("SessionDate", "Session date cannot be in the past.");
                        await PopulateDropdownsAsync();
                        return View(session);
                    }

                    await _sessionService.CreateAsync(session);
                    TempData["SuccessMessage"] = "Session created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating session: {ex.Message}");
                }
            }
            
            await PopulateDropdownsAsync();
            return View(session);
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var session = await _sessionService.GetByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            
            await PopulateDropdownsAsync();
            return View(session);
        }

        // POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Validate session times
                    if (session.StartTime >= session.EndTime)
                    {
                        ModelState.AddModelError("EndTime", "End time must be after start time.");
                        await PopulateDropdownsAsync();
                        return View(session);
                    }

                    await _sessionService.UpdateAsync(session);
                    TempData["SuccessMessage"] = "Session updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating session: {ex.Message}");
                }
            }
            
            await PopulateDropdownsAsync();
            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var session = await _sessionService.GetByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _sessionService.DeleteAsync(id);
                if (success)
                {
                    TempData["SuccessMessage"] = "Session deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Session not found.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting session: {ex.Message}";
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Sessions/ToggleStatus/5
        public async Task<IActionResult> ToggleStatus(int id)
        {
            try
            {
                var session = await _sessionService.GetByIdAsync(id);
                if (session == null)
                {
                    TempData["ErrorMessage"] = "Session not found.";
                    return RedirectToAction(nameof(Index));
                }

                session.IsActive = !session.IsActive;
                await _sessionService.UpdateAsync(session);
                
                TempData["SuccessMessage"] = $"Session {(session.IsActive ? "activated" : "deactivated")} successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating session status: {ex.Message}";
            }
            
            return RedirectToAction(nameof(Index));
        }

        // API endpoint for getting upcoming sessions (for AJAX calls)
        [HttpGet]
        public async Task<IActionResult> GetUpcomingSessions()
        {
            try
            {
                var sessions = await _sessionService.GetUpcomingSessionsAsync();
                return Json(sessions.Select(s => new { 
                    id = s.Id, 
                    filmTitle = s.Film?.Title,
                    cinemaName = s.Cinema?.Name,
                    sessionDate = s.SessionDate.ToString("yyyy-MM-dd"),
                    startTime = s.StartTime.ToString(@"hh\:mm"),
                    endTime = s.EndTime.ToString(@"hh\:mm")
                }));
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // API endpoint for checking session conflicts
        [HttpPost]
        public async Task<IActionResult> CheckConflict(int cinemaId, DateTime sessionDate, TimeSpan startTime, TimeSpan endTime, int? excludeSessionId = null)
        {
            try
            {
                var hasConflict = await _sessionService.HasConflictingSessionAsync(cinemaId, sessionDate, startTime, endTime, excludeSessionId);
                return Json(new { hasConflict });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        private async Task PopulateDropdownsAsync()
        {
            ViewBag.filmId = new SelectList(await _filmService.GetActiveFilmsAsync(), "Id", "Title");
            ViewBag.CinemaId = new SelectList(await _cinemaService.GetAllAsync(), "Id", "Name");
        }
    }
}