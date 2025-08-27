using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Authorization;
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
      public async Task<IActionResult> Create([Bind("FullName,ProfilePicture,Biography")] Actor actor)
      {
         if (!ModelState.IsValid)
         {
            return View(actor);
         }

         await _service.Add(actor);

         return RedirectToAction(nameof(Index));
      }

      [AllowAnonymous]
      public IActionResult Details(int id)
      {
         if (id == 0) return View(this);

         Actor actorDetails = _service.GetById(id).Result;

         if (actorDetails == null)
         {
            return View("Details");
         }
         else
         {
            return View(actorDetails);
         }
      }

      public IActionResult Edit(int id)
      {
         Actor actorDetails = _service.GetById(id).Result;

         if (actorDetails == null)
         {
            return View("Details");
         }
         else
         {
            return View(actorDetails);
         }
      }

      [HttpPost]
      public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePicture,Biography")] Actor actor)
      {
         if (!ModelState.IsValid)
         {
            return View(actor);
         }

         await _service.Update(id, actor);

         return RedirectToAction(nameof(Index));
      }
   }
}
