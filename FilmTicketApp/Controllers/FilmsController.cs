using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var filmDropdownsData = await _filmsService.GetNewFilmDropdownsValues();

         ViewBag.CinemaId = new SelectList(filmDropdownsData.Cinemas, "Id", "Name");
         ViewBag.ProducerId = new SelectList(filmDropdownsData.Producers, "Id", "FullName");
         ViewBag.ActorId = new SelectList(filmDropdownsData.Actors, "Id", "FullName");

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
