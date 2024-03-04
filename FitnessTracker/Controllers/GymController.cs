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

		public async Task<IActionResult> All()
		{
			var model = await service.GetAllAsync();

			return View(model);
		}
	}
}
