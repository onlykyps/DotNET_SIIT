using FilmTicketApp.Data.ViewModels;
using FilmTicketApp.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    public class ChangePricesViewModel
    {
        public List<TicketTypePriceUpdate> TicketTypes { get; set; } = new List<TicketTypePriceUpdate>();
    }

    public class TicketTypePriceUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketCategory Category { get; set; }
        public bool Is3D { get; set; }
        public bool IsReduced { get; set; }
        public decimal CurrentPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Display(Name = "New Price")]
        public decimal NewPrice { get; set; }
    }

    public class SeatAvailabilityViewModel
    {
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public int OccupiedSeats { get; set; }
        public double OccupancyRate => TotalSeats > 0 ? (double)OccupiedSeats / TotalSeats * 100 : 0;
        public double AvailabilityRate => TotalSeats > 0 ? (double)AvailableSeats / TotalSeats * 100 : 0;
    }

    public class AdminDashboardViewModel
    {
        public SeatAvailabilityViewModel SeatStats { get; set; } = null!;
        public int TotalReservations { get; set; }
        public int TodayReservations { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TodayRevenue { get; set; }
    }
}