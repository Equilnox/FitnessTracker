using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Gym;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class AthleteGymController : Controller
    {
		private readonly IAthleteGymService service;

        public AthleteGymController(IAthleteGymService _service)
        {
            service = _service;
        }

        [HttpGet]
		public IActionResult Renew(int athleteId, int gymId)
		{
			var model = new GymMembershipRenewFormModel()
			{
				AthleteId = athleteId,
				GymId = gymId
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Renew(GymMembershipRenewFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model = new GymMembershipRenewFormModel()
				{
					AthleteId = model.AthleteId,
					GymId = model.GymId
				};

				return View(model);
			}

			await service.RenewAsync(model);

			return RedirectToAction("Details", "Gym", new { id = model.GymId });;
		}
	}
}
