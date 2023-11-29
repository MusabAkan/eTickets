using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController(IProducersService service) : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await service.GetAllAsync();
            return View(allProducers);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if(id == producer.Id)
            {
                await service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
