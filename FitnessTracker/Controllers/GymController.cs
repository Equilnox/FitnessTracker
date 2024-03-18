using FitnessTracker.Core.Contracts;
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
			var model = await service.GetAllAsync();

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
	}
}
