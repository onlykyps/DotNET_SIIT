using Microsoft.AspNetCore.Mvc;
using FilmTicketApp.Data;
using FilmTicketApp.ViewModels;
using FilmTicketApp.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace FilmTicketApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext _context;

        public AccountController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if admin exists, if not create default admin
            var adminExists = await _context.Admins.AnyAsync();
            if (!adminExists)
            {
                var defaultAdmin = new Admin
                {
                    Email = "admin@filmticket.com",
                    PasswordHash = HashPassword("Admin123!")
                };
                _context.Admins.Add(defaultAdmin);
                await _context.SaveChangesAsync();
            }

            // First, try to authenticate as admin
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == model.Email);
            if (admin != null && VerifyPassword(model.Password, admin.PasswordHash))
            {
                // Set session for admin
                HttpContext.Session.SetString("AdminId", admin.Id.ToString());
                HttpContext.Session.SetString("AdminEmail", admin.Email);
                HttpContext.Session.SetString("UserRole", "Admin");
                
                // Also set authentication cookie for [Authorize] attributes
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };
                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity), authProperties);
                
                return RedirectToAction("Index", "Home");
            }

            // If not admin, allow regular user login (for demo purposes, any valid email/password combo)
            // In a real application, you would check against a Users table
            if (model.Email.Contains("@") && model.Password.Length >= 6)
            {
                var userId = Guid.NewGuid().ToString();
                // Set session for regular user
                HttpContext.Session.SetString("UserId", userId);
                HttpContext.Session.SetString("UserEmail", model.Email);
                HttpContext.Session.SetString("UserRole", "User");
                
                // Also set authentication cookie for [Authorize] attributes
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Role, "User")
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };
                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity), authProperties);
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if admin with this email already exists
            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == model.Email);
            if (existingAdmin != null)
            {
                ModelState.AddModelError("Email", "An account with this email already exists.");
                return View(model);
            }

            // Create new admin
            var newAdmin = new Admin
            {
                Email = model.Email,
                PasswordHash = HashPassword(model.Password)
            };

            _context.Admins.Add(newAdmin);
            await _context.SaveChangesAsync();

            // Automatically log in the new admin
            HttpContext.Session.SetString("AdminId", newAdmin.Id.ToString());
            HttpContext.Session.SetString("AdminEmail", newAdmin.Email);
            HttpContext.Session.SetString("UserRole", "Admin");

            // Also set authentication cookie for [Authorize] attributes
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newAdmin.Id.ToString()),
                new Claim(ClaimTypes.Email, newAdmin.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }

        // Helper method to check if user is authenticated
        public static bool IsAuthenticated(HttpContext httpContext)
        {
            return !string.IsNullOrEmpty(httpContext.Session.GetString("AdminId")) || 
                   !string.IsNullOrEmpty(httpContext.Session.GetString("UserId"));
        }

        // Helper method to check if user is admin
        public static bool IsAdmin(HttpContext httpContext)
        {
            return httpContext.Session.GetString("UserRole") == "Admin";
        }

        // Helper method to get current user email
        public static string GetUserEmail(HttpContext httpContext)
        {
            return httpContext.Session.GetString("AdminEmail") ?? 
                   httpContext.Session.GetString("UserEmail") ?? string.Empty;
        }

        // Helper method to get current user role
        public static string GetUserRole(HttpContext httpContext)
        {
            return httpContext.Session.GetString("UserRole") ?? "Guest";
        }

        // Helper method to hash passwords
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Helper method to verify passwords
        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}