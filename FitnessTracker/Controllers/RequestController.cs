﻿using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Request;
using FitnessTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
	[Authorize]
	public class RequestController : Controller
	{
		public readonly IRequestService service;
		public readonly IExerciseService exerciseService;
		public readonly ILogger logger;

		public RequestController(IRequestService _service, IExerciseService _exerciseService, ILogger<RequestController> _logger)
		{
			service = _service;
			exerciseService = _exerciseService;
			logger = _logger;
		}

		[HttpGet]
		public IActionResult AddExercise()
		{
			var model = new AddExerciseFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddExerciseAsync(AddExerciseFormModel model)
		{
			if(!ModelState.IsValid)
			{
				model = new AddExerciseFormModel();

				return View(model);
			}

			var userId = User.Id();

			await service.AddExerciseAsync(model, userId);

			return RedirectToAction("Index", "Athlete");
		}

		[HttpGet]
		public async Task<IActionResult> EditExercise(int id)
		{
			var exerciseToEdit = await exerciseService.FindExerciseAsNoTracingAsync(id);

			var model = new EditExerciseFormModel()
			{
				Id = exerciseToEdit.Id,
				Name = exerciseToEdit.Name,
				Description = exerciseToEdit.Description
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditExercise(EditExerciseFormModel model)
		{
			if (!ModelState.IsValid)
			{
				int exerciseId = model.Id;
				string exerciseName = model.Name;
				string exerciseDescription = model.Description;

				model = new EditExerciseFormModel()
				{
					Id = exerciseId,
					Name = exerciseName,
					Description = exerciseDescription
				};

				return View(model);
			}

			var userId = User.Id();

			await service.EditExerciseAsync(model, userId);

			return RedirectToAction("Index", "Athlete");
		}
	}
}
