using System.Diagnostics;
using FilmTicketApp.Models;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeatManagementService _seatService;
        private readonly AppDBContext _context;

        public HomeController(ILogger<HomeController> logger, ISeatManagementService seatService, AppDBContext context)
        {
            _logger = logger;
            _seatService = seatService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _seatService.InitializeTheaterSeatsAsync();
            var seatStats = await _seatService.GetSeatAvailabilityAsync();
            var ticketTypes = await _seatService.GetTicketTypesAsync();

            // Get comprehensive booking statistics
            var totalBookings = await _context.TicketReservations.CountAsync();
            var todayBookings = await _context.TicketReservations
                .Where(tr => tr.ReservationDate.Date == DateTime.Today)
                .CountAsync();
            var totalRevenue = await _context.TicketReservations
                .Include(tr => tr.TicketType)
                .SumAsync(tr => tr.TicketType.Price);
            var todayRevenue = await _context.TicketReservations
                .Include(tr => tr.TicketType)
                .Where(tr => tr.ReservationDate.Date == DateTime.Today)
                .SumAsync(tr => tr.TicketType.Price);
            var activeSessions = await _context.Sessions
                .Where(s => s.SessionDate >= DateTime.Today)
                .CountAsync();
            var uniqueCustomers = await _context.TicketReservations
                .Select(tr => tr.CustomerEmail)
                .Distinct()
                .CountAsync();
            var averageTicketPrice = totalBookings > 0 ? totalRevenue / totalBookings : 0;

            ViewBag.TicketTypes = ticketTypes;
            ViewBag.TotalBookings = totalBookings;
            ViewBag.TodayBookings = todayBookings;
            ViewBag.TotalRevenue = totalRevenue;
            ViewBag.TodayRevenue = todayRevenue;
            ViewBag.ActiveSessions = activeSessions;
            ViewBag.UniqueCustomers = uniqueCustomers;
            ViewBag.AverageTicketPrice = averageTicketPrice;

            return View(seatStats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
