using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
	public class GymController : Controller
	{
		private readonly IGymService service;

		public GymController(IGymService _service)
		{
			service = _service;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await service.GetAllPublicAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var userId = User.Id();

			var model = await service.GetGymAsync(id);

			ViewBag.UserId = userId;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> MyGym()
		{
			var userId = User.Id();

			var gymId = await service.GetGymIdByUserIdAsync(userId);

			if(gymId != 0)
			{
				return RedirectToAction(nameof(Details), new { id = gymId });
			}

			return Unauthorized();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var gymDetails = await service.GetGymAsync(id);

			var userId = User.Id();

			if(gymDetails.OwnerId != userId)
			{
				return Unauthorized();
			}

			var model = new GymDetailsFormViewModel()
			{
				Id = gymDetails.Id,
				GymName = gymDetails.Name,
				Address = gymDetails.Address,
				PhoneNumber = gymDetails.PhoneNumber,
				PricePerMonth = decimal.Parse(gymDetails.PricePerMonth)
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(GymDetailsFormViewModel model)
		{
			int gymId = model.Id;

			var gym = await service.GetGymDetailsAsync(gymId);

			if (!ModelState.IsValid)
			{
				model = new GymDetailsFormViewModel()
				{
					Id = gymId,
					GymName = gym.GymName,
					Address = gym.Address,
					PhoneNumber = gym.PhoneNumber,
					PricePerMonth = gym.PricePerMonth
				};

				return View(model);
			}

			gymId = await service.ChangeGymDetailsAsync(model);

			return RedirectToAction(nameof(Details), new { id = gymId });
		}

		[HttpPost]
		public async Task<IActionResult> ChangeGymType(GymTypeFormModel model)
		{
			;
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await service.ChangeGymTypeAsync(model);

			return RedirectToAction(nameof(Details), new { id = model.Id });
		}
    }
}
