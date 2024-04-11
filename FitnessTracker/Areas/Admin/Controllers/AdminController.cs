using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Infrastructure.Data.Models.Enums;
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
			var model = await requestService.GetDoneRequestsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Dismiss()
		{
			var model = await requestService.GetDismissedRequestsAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> RequestDetails(int id) 
		{
			if (await requestService.RequestExistsAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await requestService.GetRequestsAsync(id);

            DateTime date = DateTime.Parse(model.DateCreated);
            string dateCreated = date.ToShortDateString();

            string dateDone = string.Empty;

            if (model.RequestStatus != RequestStatus.Pending.ToString())
            {
                date = DateTime.Parse(model.DateApproved);
				dateDone = date.ToShortDateString();
            }

            ViewBag.DateDone = dateDone;
			ViewBag.DateCreated = dateCreated;

            return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ApproveExercise(int id)
		{
			await requestService.ApproveExerciseAsync(id);

			return Json( new { succsess = true });
		}

		[HttpPost]
		public async Task<IActionResult> ApproveChanges(int id)
		{
			await requestService.ApproveChangesAsync(id);

            return Json(new { succsess = true });
        }

		[HttpPost]
		public async Task<IActionResult> DismissRequest(int id)
		{
			await requestService.Dismiss(id);

			return Json(new { succsess = true });
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
