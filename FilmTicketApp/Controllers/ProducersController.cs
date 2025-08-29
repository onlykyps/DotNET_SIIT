using FilmTicketApp.Data;
using FilmTicketApp.Data.Services;
using FilmTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FilmTicketApp.Controllers
{
   public class ProducersController : Controller
   {
      private readonly IProducersService _producersService;

      public ProducersController(IProducersService producersService)
      {
         _producersService = producersService;
      }

      public async Task<IActionResult> Index()
      {
         var data = await _producersService.GetAll();
         return View(data);
      }

      public async Task<IActionResult> Details(int id)
      {
         var producerDetails = await _producersService.GetById(id);

         if (producerDetails == null)
         {
            return View("NotFound");
         }

         return View(producerDetails);
      }

      public async Task<IActionResult> Create() 
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Create([Bind("FullName,ProfilePicture,Biography")] Producer producer)
      {
         if(!ModelState.IsValid)
         {
            return View(producer);
         }

         await _producersService.Add(producer);

         return RedirectToAction(nameof(Index));
      }
   }
}
