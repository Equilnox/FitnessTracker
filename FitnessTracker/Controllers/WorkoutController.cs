using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Workout;
using FitnessTracker.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FitnessTracker.Controllers
{
	public class WorkoutController : Controller
	{
		private readonly IWorkoutService service;
		private readonly IAthleteGymService athleteGymService;

		public WorkoutController(IWorkoutService _service, IAthleteGymService _athleteGymService)
		{
			service = _service;
			athleteGymService = _athleteGymService;
		}

		[HttpGet]
		public async Task<IActionResult> AddWorkout()
		{
			var model = new WorkoutFormModel();

			List<WorkoutIntensitiesFormModel> workoutData = new List<WorkoutIntensitiesFormModel>();

			if (TempData["WorkoutData"] is string json)
			{
				workoutData = JsonSerializer.Deserialize<List<WorkoutIntensitiesFormModel>>(json);

				TempData.Keep("WorkoutData");
			}

			model.WorkoutIntensities = workoutData;

			var exercises = await service.GetExercises();

			var userEmail = User.Email();

			var athleteId = await athleteGymService.GetAthleteId(userEmail);

			var gyms = await service.GetGyms(athleteId);

			ViewBag.WorkoutData = workoutData;
			ViewBag.Exercises = exercises;
			ViewBag.Gyms = gyms;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddWorkout(WorkoutFormModel model)
		{
			if (TempData["WorkoutData"] is string json)
			{
				List<WorkoutIntensitiesFormModel> workoutData = JsonSerializer.Deserialize<List<WorkoutIntensitiesFormModel>>(json);

				model.WorkoutIntensities = workoutData.ToList();
			}

			var userEmail = User.Email();

			var athleteId = await athleteGymService.GetAthleteId(userEmail);

			if (!ModelState.IsValid)
			{
				model = new WorkoutFormModel();

				List<WorkoutIntensitiesFormModel> workoutData = new List<WorkoutIntensitiesFormModel>();

				if (TempData["WorkoutData"] is string data)
				{
					workoutData = JsonSerializer.Deserialize<List<WorkoutIntensitiesFormModel>>(data);

					TempData.Keep("WorkoutData");
				}

				var exercises = await service.GetExercises();

				var gyms = await service.GetGyms(athleteId);

				ViewBag.WorkoutData = workoutData;
				ViewBag.Exercises = exercises;
				ViewBag.Gyms = gyms;

				return View(model);
			}

			TempData.Clear();

			await service.CreateWorkout(model, athleteId);

			return RedirectToAction("Index", "Athlete");
		}

		[HttpPost]
		public IActionResult AddExercise(WorkoutIntensitiesFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (TempData.ContainsKey("WorkoutData"))
			{
				string json = string.Empty;

				if (TempData["WorkoutData"] is string data)
				{
					json = data;
				}

				List<WorkoutIntensitiesFormModel> workoutData = JsonSerializer.Deserialize<List<WorkoutIntensitiesFormModel>>(json);

				workoutData.Add(model);

				json = JsonSerializer.Serialize<List<WorkoutIntensitiesFormModel>>(workoutData);

				TempData["WorkoutData"] = json;
			}
			else
			{
				List<WorkoutIntensitiesFormModel> workoutData = new List<WorkoutIntensitiesFormModel>();

				workoutData.Add(model);

				string json = JsonSerializer.Serialize<List<WorkoutIntensitiesFormModel>>(workoutData);

				TempData["WorkoutData"] = json;
			}

			return RedirectToAction(nameof(AddWorkout));
		}
	}
}