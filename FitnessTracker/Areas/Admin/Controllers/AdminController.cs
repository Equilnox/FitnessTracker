using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Exercise;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Areas.Admin.Controllers
{
	public class AdminController : AdminBaseController
	{
		private readonly IRequestService requestService;
		private readonly IExerciseService exerciseService;

		public AdminController(
			IRequestService _requestService,
			IExerciseService _exerciseService
		)
		{
			requestService = _requestService;
			exerciseService = _exerciseService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = await requestService.GetPendingRequestsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Done()
		{
			var model = await requestService.GetPendingRequestsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> RequestDetails(int id) 
		{
			var model = await requestService.GetRequestsAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task ApproveExercise(int id)
		{
			await requestService.ApproveExerciseAsync(id);

			RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult AddExercise()
		{
			var model = new ExerciseFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddExercise(ExerciseFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model = new ExerciseFormModel();

				return View(model);
			}

			await exerciseService.AddNewAsync(model);

			return RedirectToAction(nameof(AddExercise));
		}
	}
}
