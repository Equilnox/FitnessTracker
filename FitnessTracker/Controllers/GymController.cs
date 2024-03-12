using FitnessTracker.Core.Contracts;
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
			var model = await service.GetGymAsync(id);

			return View(model);
		}
	}
}
