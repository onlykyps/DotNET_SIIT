using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ISeatManagementService _seatService;
        public TicketsController(
            AppDBContext context,
            ISeatManagementService seatService)
        {
            _context = context;
            _seatService = seatService;
        }

        private string GenerateUniqueBookingReference()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var random = new Random().Next(1000, 9999);
            return $"BK{timestamp}{random}";
        }

        private bool AreSeatsConsecutive(List<Seat> seats)
        {
            if (seats == null || seats.Count == 0)
                return true;
                
            if (seats.Count == 1)
                return true;
                
            // Check if all seats are in the same row
            var firstRow = seats[0].Row;
            if (seats.Any(s => s.Row != firstRow))
                return false;
                
            // Sort seats by seat number
            var sortedSeats = seats.OrderBy(s => s.SeatNumber).ToList();
            
            // Check if seats are consecutive
            for (int i = 1; i < sortedSeats.Count; i++)
            {
                if (sortedSeats[i].SeatNumber - sortedSeats[i-1].SeatNumber != 1)
                    return false;
            }
            
            return true;
        }

        // GET: Tickets/SelectCinema
        [Authorize]
        public async Task<IActionResult> SelectCinema()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return View(cinemas);
        }

        // GET: Tickets/SelectFilm
        [Authorize]
        public async Task<IActionResult> SelectFilm(int cinemaId)
        {
            var cinema = await _context.Cinemas.FindAsync(cinemaId);
            if (cinema == null)
            {
                return NotFound();
            }

            var movies = await _context.Films
                .Where(m => m.IsActive)
                .ToListAsync();

            var model = new SelectFilmViewModel
            {
                Cinema = cinema,
                Films = movies
            };

            return View(model);
        }

        // GET: Tickets/SelectSession
        [Authorize]
        public async Task<IActionResult> SelectSession(int cinemaId, int movieId)
        {
            var cinema = await _context.Cinemas.FindAsync(cinemaId);
            var movie = await _context.Films.FindAsync(movieId);

            if (cinema == null || movie == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions
                .Where(s => s.CinemaId == cinemaId && s.FilmId == movieId && s.IsActive)
                .Where(s => s.SessionDate >= DateTime.Today)
                .OrderBy(s => s.SessionDate)
                .ToListAsync();

            // Order by StartTime on the client side since SQLite doesn't support TimeSpan in ORDER BY
            sessions = sessions.OrderBy(s => s.SessionDate).ThenBy(s => s.StartTime).ToList();

            var model = new SelectSessionViewModel
            {
                Cinema = cinema,
                Film = movie,
                Sessions = sessions
            };

            return View(model);
        }

        // GET: Tickets/SelectSeats
        public async Task<IActionResult> SelectSeats(int sessionId)
        {
            // Check if user is authenticated
            if (!AccountController.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }

            var session = await _context.Sessions
                .Include(s => s.Cinema)
                .Include(s => s.Film)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
            {
                return NotFound();
            }

            // Get or create seats for this cinema
            var seats = await GetOrCreateCinemaSeats(session.CinemaId);
            var ticketTypes = await _seatService.GetTicketTypesAsync();

            var seatGrid = new List<List<Seat>>();
            for (int row = 1; row <= 20; row++)
            {
                var rowSeats = seats.Where(s => s.Row == row).OrderBy(s => s.SeatNumber).ToList();
                seatGrid.Add(rowSeats);
            }

            var model = new SelectSeatsViewModel
            {
                Session = session,
                SeatGrid = seatGrid,
                TicketTypes = ticketTypes,
                TotalSeats = seats.Count,
                AvailableSeats = seats.Count(s => s.IsAvailableForSession(sessionId)),
                OccupiedSeats = seats.Count(s => !s.IsAvailableForSession(sessionId))
            };

            return View(model);
        }

        // POST: Tickets/BookTickets
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookTickets(BookTicketsViewModel model)
        {
            // Debug: Log the received model data
            Console.WriteLine($"BookTickets called with: SessionId={model.SessionId}, TicketTypeId={model.TicketTypeId}, SelectedSeatIds='{model.SelectedSeatIds}'");
            
            // Check if user is authenticated
            if (!AccountController.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
                    .ToList();
                
                // Log the validation errors for debugging
                foreach (var error in errors)
                {
                    Console.WriteLine($"Validation Error - Field: {error.Field}, Errors: {string.Join(", ", error.Errors)}");
                }
                
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }

            var session = await _context.Sessions
                .Include(s => s.Cinema)
                .Include(s => s.Film)
                .FirstOrDefaultAsync(s => s.Id == model.SessionId);

            if (session == null)
            {
                return NotFound();
            }


            var ticketType = await _context.TicketTypes.FindAsync(model.TicketTypeId);

            if (ticketType == null)
            {
                return BadRequest("Invalid ticket type");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var seatsToBook = new List<Seat>();
                
                // Validate and reserve seats
                var selectedSeatIds = model.GetSelectedSeatIds();
                var selectedSeats = new List<Seat>();
                
                // First, get all selected seats
                foreach (var seatId in selectedSeatIds)
                {
                    var seat = await _context.Seats
                        .Include(s => s.Reservations)
                        .FirstOrDefaultAsync(s => s.Id == seatId);
                    
                    if (seat == null || !seat.IsAvailableForSession(model.SessionId))
                    {
                        throw new InvalidOperationException($"Seat {seatId} is not available for this session");
                    }
                    
                    selectedSeats.Add(seat);
                }
                
                // Validate consecutive seat allocation
                if (!AreSeatsConsecutive(selectedSeats))
                {
                    throw new InvalidOperationException("Selected seats must be consecutive and in the same row");
                }
                
                // Mark seats as occupied
                foreach (var seat in selectedSeats)
                {
                    seat.IsOccupied = true;
                    seatsToBook.Add(seat);
                }

                // Get current user information
                var userEmail = AccountController.GetUserEmail(HttpContext);
                var userName = userEmail.Split('@')[0]; // Use part before @ as name
                
                // Create reservations
                var reservations = new List<TicketReservation>();
                foreach (var seat in seatsToBook)
                {
                    var reservation = new TicketReservation
                    {
                        SeatId = seat.Id,
                        SessionId = model.SessionId,
                        TicketTypeId = model.TicketTypeId,
                        ReservationDate = DateTime.Now,
                        TotalAmount = ticketType.Price,
                        CustomerName = userName,
                        CustomerEmail = userEmail,
                        BookingReference = GenerateUniqueBookingReference()
                    };

                    reservations.Add(reservation);
                    _context.TicketReservations.Add(reservation);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["SuccessMessage"] = $"Successfully booked {seatsToBook.Count} tickets for {session.Film.Name}!";
                return RedirectToAction("BookingConfirmation", new { sessionId = model.SessionId });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["ErrorMessage"] = $"Booking failed: {ex.Message}";
                return RedirectToAction("SelectSeats", new { sessionId = model.SessionId });
            }
        }

        // GET: Tickets/BookingConfirmation
        [Authorize]
        public async Task<IActionResult> BookingConfirmation(int sessionId)
        {
            var session = await _context.Sessions
                .Include(s => s.Cinema)
                .Include(s => s.Film)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
            {
                return NotFound();
            }

            var userReservations = await _context.TicketReservations
                .Include(tr => tr.Seat)
                .Include(tr => tr.TicketType)
                .Where(tr => tr.SessionId == sessionId)
                .OrderByDescending(tr => tr.ReservationDate)
                .Take(10) // Get recent bookings
                .ToListAsync();

            var model = new BookingConfirmationViewModel
            {
                Session = session,
                Reservations = userReservations
            };

            return View(model);
        }

        // GET: Tickets/ReturnTickets (for regular users to view all their tickets)
        [Route("Tickets/ReturnTickets")]
        [Authorize]
        public async Task<IActionResult> ReturnTickets()
        {
            // Check if user is authenticated
            if (!AccountController.IsAuthenticated(HttpContext))
            {
                return RedirectToAction("Login", "Account");
            }

            var userEmail = AccountController.GetUserEmail(HttpContext);
            
            // Get all reservations for the current user
            var userReservations = await _context.TicketReservations
                .Include(tr => tr.Seat)
                .Include(tr => tr.TicketType)
                .Include(tr => tr.Session)
                    .ThenInclude(s => s.Cinema)
                .Include(tr => tr.Session)
                    .ThenInclude(s => s.Film)
                .Where(tr => tr.CustomerEmail == userEmail)
                .OrderByDescending(tr => tr.ReservationDate)
                .ToListAsync();

            return View(userReservations);
        }

        // GET: Tickets/ReturnTickets (for specific session)
        [Route("Tickets/ReturnTickets/{sessionId:int}")]
        public async Task<IActionResult> ReturnTickets(int sessionId)
        {
            var session = await _context.Sessions
                .Include(s => s.Cinema)
                .Include(s => s.Film)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
            {
                return NotFound();
            }

            // Show all reservations for this session since users might not be logged in
            var userReservations = await _context.TicketReservations
                .Include(tr => tr.Seat)
                .Include(tr => tr.TicketType)
                .Where(tr => tr.SessionId == sessionId)
                .ToListAsync();

            // If user is logged in, filter to show only their reservations
            var userEmail = User.Identity?.Name;
            if (!string.IsNullOrEmpty(userEmail))
            {
                userReservations = userReservations.Where(tr => tr.CustomerEmail == userEmail).ToList();
            }

            var model = new ReturnTicketsViewModel
            {
                Session = session,
                Reservations = userReservations
            };

            return View("ReturnTicketsForSession", model);
        }

        // POST: Tickets/ProcessReturn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessReturn(int[] reservationIds)
        {
            if (reservationIds == null || reservationIds.Length == 0)
            {
                TempData["ErrorMessage"] = "Please select tickets to return.";
                return RedirectToAction("ReturnTickets");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                decimal totalRefund = 0;
                var returnedSeats = new List<Seat>();

                foreach (var reservationId in reservationIds)
                {
                    var reservation = await _context.TicketReservations
                        .Include(tr => tr.Seat)
                        .FirstOrDefaultAsync(tr => tr.Id == reservationId);

                    if (reservation != null && reservation.Seat != null)
                    {
                        reservation.Seat.IsOccupied = false;
                        totalRefund += reservation.TotalAmount;
                        returnedSeats.Add(reservation.Seat);
                        
                        _context.TicketReservations.Remove(reservation);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["SuccessMessage"] = $"Successfully returned {returnedSeats.Count} tickets. Refund amount: ${totalRefund:F2}";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["ErrorMessage"] = $"Return failed: {ex.Message}";
                return RedirectToAction("ReturnTickets");
            }
        }

        private async Task<List<Seat>> GetOrCreateCinemaSeats(int cinemaId)
        {
            var existingSeats = await _context.Seats
                .Where(s => s.CinemaId == cinemaId)
                .Include(s => s.Reservations)
                .ToListAsync();

            if (existingSeats.Any())
            {
                return existingSeats;
            }

            // Create seats for this cinema (20x20 grid)
            var seats = new List<Seat>();
            for (int row = 1; row <= 20; row++)
            {
                for (int seatNumber = 1; seatNumber <= 20; seatNumber++)
                {
                    seats.Add(new Seat
                    {
                        Row = row,
                        SeatNumber = seatNumber,
                        CinemaId = cinemaId,
                        CreatedDate = DateTime.Now
                    });
                }
            }

            _context.Seats.AddRange(seats);
            await _context.SaveChangesAsync();
            
            return seats;
        }
    }

    // View Models
    public class SelectFilmViewModel
    {
        public Cinema Cinema { get; set; } = null!;
        public List<Film> Films { get; set; } = new List<Film>();
    }

    public class SelectSessionViewModel
    {
        public Cinema Cinema { get; set; } = null!;
        public Film Film { get; set; } = null!;
        public List<Session> Sessions { get; set; } = new List<Session>();
    }

    public class SelectSeatsViewModel
    {
        public Session Session { get; set; } = null!;
        public List<List<Seat>> SeatGrid { get; set; } = new List<List<Seat>>();
        public List<TicketType> TicketTypes { get; set; } = new List<TicketType>();
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int OccupiedSeats { get; set; }
    }

    public class BookTicketsViewModel
    {
        [Required]
        public int SessionId { get; set; }
        
        [Required]
        public int TicketTypeId { get; set; }
        
        [Required]
        public string SelectedSeatIds { get; set; } = string.Empty;
        
        public List<int> GetSelectedSeatIds()
        {
            if (string.IsNullOrEmpty(SelectedSeatIds))
                return new List<int>();
                
            return SelectedSeatIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();
        }
    }

    public class BookingConfirmationViewModel
    {
        public Session Session { get; set; } = null!;
        public List<TicketReservation> Reservations { get; set; } = new List<TicketReservation>();
    }

    public class ReturnTicketsViewModel
    {
        public Session Session { get; set; } = null!;
        public List<TicketReservation> Reservations { get; set; } = new List<TicketReservation>();
    }
}