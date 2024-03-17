using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.AthleteGym;
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

		[HttpGet]
		public async Task<IActionResult> AddMember(int gymId)
		{
			var newMember = new NewMembershipFormModel()
			{
				GymId = gymId
			};

			return View(newMember);
		}

		[HttpPost]
		public async Task<IActionResult> AddMember(NewMembershipFormModel model)
		{
			int gymId = model.GymId;

			if (await service.AthleteExists(model.UserEmail) == false)
			{
				//TODO Add Error Message!!
				model = new NewMembershipFormModel()
				{
					GymId = gymId
				};

				return View(model);
			}

			var athleteId = await service.GetAthleteId(model.UserEmail);

			if(athleteId <= 0)
			{

				//TODO Add Error Message!!
				model = new NewMembershipFormModel()
				{
					GymId = gymId
				};

				return View(model);
			}

			if (!ModelState.IsValid)
			{
				model = new NewMembershipFormModel()
				{
					GymId = gymId
				};

				return View(model);
			}

			await service.AddNewMember(model, athleteId);

			return RedirectToAction("Details", "Gym", new { id = model.GymId });
		}
	}
}
