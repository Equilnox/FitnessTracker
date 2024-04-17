using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Extensions;
using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
	[Authorize]
	public class GymController : Controller
	{
		private readonly IGymService service;

		public GymController(IGymService _service)
		{
			service = _service;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await service.GetAllPublicAsync();

			return View(model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			if (await service.GymExistsAsync(id) == false)
			{
				return NotFound();
			}
			
			var userId = User.Id();

			var model = await service.GetGymAsync(id);

			if (await service.GymIsPublic(id) == false && model.OwnerId != userId)
			{
				return BadRequest();
			}

			if (information != model.GetGymInformation())
			{
				return BadRequest();
			}

			ViewBag.UserId = userId;

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> MyGym()
		{
			var userId = User.Id();

			var gym = await service.GetGymByUserIdAsync(userId);

			if(gym.OwnerId != userId)
			{
				return Unauthorized();
			}

			return RedirectToAction(nameof(Details), new { id = gym.Id, information = gym.GetGymInformation() });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id, string information)
        {
            if (await service.GymExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var gymDetails = await service.GetGymAsync(id);

			var userId = User.Id();

			if(gymDetails.OwnerId != userId)
			{
				return Unauthorized();
			}

			var model = new GymDetailsFormViewModel()
			{
				Id = gymDetails.Id,
				Name = gymDetails.Name,
				Address = gymDetails.Address,
				PhoneNumber = gymDetails.PhoneNumber,
				PricePerMonth = decimal.Parse(gymDetails.PricePerMonth)
			};

			if(information != model.GetGymInformation())
			{
				return BadRequest();
			}

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
					Name = gym.Name,
					Address = gym.Address,
					PhoneNumber = gym.PhoneNumber,
					PricePerMonth = gym.PricePerMonth
				};

				return View(model);
			}

			gymId = await service.ChangeGymDetailsAsync(model);

			return RedirectToAction(nameof(Details), new { id = gymId, information = model.GetGymInformation() });
		}

		[HttpPost]
		public async Task<IActionResult> ChangeGymType(GymTypeFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await service.ChangeGymTypeAsync(model);

			return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetGymInformation() });
		}
    }
}
