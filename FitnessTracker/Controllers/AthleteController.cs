using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Extensions;
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
        private readonly IGymService gymService;

        public AthleteController(IAthleteService _service, IGymService _gymService)
        {
            service = _service;
            gymService = _gymService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await service.GetAthlete(User.Id());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string information)
        {
            var model = await service.FindByIdAsync(id);

            if(model == null)
            {
                return BadRequest();
            }

            if(information != model.GetAthleteInformation())
            {
                return BadRequest();
            }

            string userId = User.Id();

            bool userIsAthlete = await service.CheckUserId(userId, id);

            if (userIsAthlete == false)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AthleteDetailsEditFormModel athleteDetails)
        {
            if(!ModelState.IsValid)
            {
                AthleteDetailsEditFormModel model = new AthleteDetailsEditFormModel() 
                {
                    Id = athleteDetails.Id,
                    FirstName = athleteDetails.FirstName,
                    LastName = athleteDetails.LastName,
                    Age = athleteDetails.Age,
                    Weight = athleteDetails.Weight,
                    Height = athleteDetails.Height
                };

                return View(model);
            }

            await service.EditDetailsAsync(athleteDetails);
            await service.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
