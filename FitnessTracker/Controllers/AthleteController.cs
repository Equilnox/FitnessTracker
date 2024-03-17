using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Athlete;
using FitnessTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Authorize]
    public class AthleteController : Controller
    {
        private readonly IAthleteService service;

        public AthleteController(IAthleteService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await service.GetAthlete(User.Id());

            if (model == null)
            {
                return RedirectToAction(nameof(CreateAthlete));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAthlete()
        {
            AthleteCreateFormModel model = new AthleteCreateFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAthlete(AthleteCreateFormModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                model = new AthleteCreateFormModel();

                return View(model);
            }

            await service.AddNewAthleteAsync(model, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
