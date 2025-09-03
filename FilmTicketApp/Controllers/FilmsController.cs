using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmTicketApp.Controllers
{
   public class FilmsController : Controller
   {
      private readonly IFilmsService _filmsService;

      public FilmsController(IFilmsService filmsService)
      {
         _filmsService = filmsService;
      }

      public async Task<IActionResult> Index()
      {
         var data = await _filmsService.GetAll(n => n.Cinema);
         return View(data);
      }

      public async Task<IActionResult> Details(int id)
      {
         var filmDetail = await _filmsService.GetFilmById(id);

         return View(filmDetail);   
      }

      public async Task<IActionResult> Create()
      {
         ViewData["Welcome"] = "Welcome to the cinema";
         ViewBag.Description = "This is the cinema description";

         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Create([Bind("FullName,ProfilePicture,Biography")] Film film)
      {
         if (!ModelState.IsValid)
         {
            return View(film);
         }

         await _filmsService.Add(film);

         return RedirectToAction(nameof(Index));
      }

   }
}
