using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmTicketApp.Controllers
{
   public class ActorsController : Controller
   {
      private readonly IActorsService _service;

      public ActorsController(IActorsService service)
      {
         _service = service;
      }

      public async Task<IActionResult> Index()
      {
         var data = await _service.GetActors();
         return View(data);
      }

      public async Task<IActionResult> Create()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Create([Bind("FullName, ProfilePicture, Biography")]Actor actor)
      {
         if(!ModelState.IsValid)
         {
            return View(actor);
         }

         _service.Add(actor);

         return RedirectToAction(nameof(Index));
      }

      public async Task<IActionResult> Details(int id)
      {
         var actorDetails = _service.GetById(id);

         if(actorDetails == null)
         {
            return View("Empty");
         }
         else
         {
            return View(actorDetails);
         }
      }
   }
}
