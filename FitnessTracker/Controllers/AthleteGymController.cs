using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Extensions;
using FitnessTracker.Core.Models.AthleteGym;
using Microsoft.AspNetCore.Mvc;
using static FitnessTracker.Core.Constants.ModelStateErrors;

namespace FitnessTracker.Controllers
{
    public class AthleteGymController : Controller
    {
		private readonly IAthleteGymService service;
		private readonly IGymService gymService;

        public AthleteGymController(IAthleteGymService _service, IGymService _gymService)
        {
            service = _service;
			gymService = _gymService;
        }

        [HttpGet]
		public async Task<IActionResult> Renew(int athleteId, int gymId, string information)
		{

			var gym = await gymService.GetGymAsync(gymId);

			var gymInformation = gym.GetGymInformation();

			if (information != gymInformation)
			{
				return BadRequest();
			}

			var athleteIsMember = await service.AthleteIsMember(athleteId, gymId);

			if (athleteIsMember == false)
			{
				return NotFound();
			}

			var model = new GymMembershipRenewFormModel()
			{
				AthleteId = athleteId,
				GymId = gymId,
				Name = gym.Name,
				Address = gym.Address
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

			return RedirectToAction("Details", "Gym", new { id = model.GymId, information = model.GetGymInformation() });;
		}

		[HttpGet]
		public async Task<IActionResult> AddMember(int gymId, string information)
		{
			var gym = await gymService.GetGymAsync(gymId);

			var gymInformation = gym.GetGymInformation();

			if (information != gymInformation)
			{
				return BadRequest();
			}

			var newMember = new NewMembershipFormModel()
			{
				GymId = gymId,
				Name = gym.Name,
				Address = gym.Address
			};

			return View(newMember);
		}

		[HttpPost]
		public async Task<IActionResult> AddMember(NewMembershipFormModel model)
		{
			int gymId = model.GymId;

			if (await service.AthleteExists(model.UserEmail) == false)
			{
				return NotFound();
			}

			var athleteId = await service.GetAthleteId(model.UserEmail);

			if(athleteId <= 0)
			{
				ModelState.AddModelError(ErrorKeyWhenThereAreTwoIdenticalEmails, MultipleUsersWithSameEmail);

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

			return RedirectToAction("Details", "Gym", new { id = model.GymId, information = model.GetGymInformation() });
		}
	}
}
