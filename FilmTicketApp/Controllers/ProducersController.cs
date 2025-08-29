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

      public async Task<IActionResult> Edit(int id)
      {
         var details = await _producersService.GetById(id);

         if (details == null)
         {
            return View("NotFound");
         }

         return View(details);
      }

      [HttpPost]
      public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePicture,Biography")] Producer producer)
      {
         if (!ModelState.IsValid)
         {
            return View(producer);
         }

         if(id == producer.Id)
         {
            await _producersService.Update(id, producer);

            return RedirectToAction(nameof(Index));
         }

         return View(producer);
      }

      public async Task<IActionResult> Delete(int id)
      {
         var details = await _producersService.GetById(id);

         if (details == null)
         {
            return View("NotFound");
         }

         return View(details);
      }

      [HttpPost, ActionName("Delete")]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         Producer producerDetails = _producersService.GetById(id).Result;
         if (producerDetails == null)
            return View(this);

         await _producersService.Delete(id);

         return RedirectToAction(nameof(Index));
      }
   }
}
