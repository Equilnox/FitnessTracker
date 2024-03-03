using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FitnessTracker.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly FitnessTrackerDbContext data;

        public ExerciseController(FitnessTrackerDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<ExerciseViewModel> model = await GetAll();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PerMuscleGroup(int _muscleGroup)
        {
            if (!Enum.IsDefined(typeof(MuscleGroup), _muscleGroup))
            {
                return RedirectToAction(nameof(All));
            }

            var specifiedMuscleGroup = (MuscleGroup)_muscleGroup;

            var muscleGroup = specifiedMuscleGroup.ToString();

            var all = await GetAll();

            var model = all.Where(ms => ms.MuscleGroup == muscleGroup).ToList();

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var exerciseList = await GetAll();

            var model = exerciseList.FirstOrDefault(e => e.Id == id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ExerciseFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExerciseFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model = new ExerciseFormModel();

				return View(model);
			}

			int newExerciseID = await AddNew(model);

			return RedirectToAction(nameof(Details), new { id = newExerciseID });
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var exerciseToEdit = await data.Exercises.FindAsync(id);

            if (exerciseToEdit == null)
            {
                return BadRequest();
            }

			var model = new ExerciseFormModel()
            {
                Id = exerciseToEdit.Id,
                Name = exerciseToEdit.Name,
                Description = exerciseToEdit.Description,
                MuscleGroup = exerciseToEdit.MuscleGroup.ToString()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExerciseFormModel model)
        {
            var editedExercise = await data.Exercises.FindAsync(model.Id);

            if (editedExercise == null)
            {
                return BadRequest();
            }

			if (!ModelState.IsValid)
			{
				return View(model);
			}

            editedExercise.Name = model.Name;
            editedExercise.Description = model.Description;
            editedExercise.MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.MuscleGroup);

            await data.SaveChangesAsync();

			return RedirectToAction(nameof(Details), new { id = editedExercise.Id });
        }

		private async Task<int> AddNew(ExerciseFormModel model)
		{
			var newExercise = new Exercise()
			{
				Name = model.Name,
				Description = model.Description,
				MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.MuscleGroup)
			};

			await data.AddAsync(newExercise);
			await data.SaveChangesAsync();

			return newExercise.Id;
		}

		private async Task<List<ExerciseViewModel>> GetAll()
        {
            return await data.Exercises
                            .Select(e => new ExerciseViewModel
							{
                                Id = e.Id,
                                Name = e.Name,
                                Description = e.Description,
                                MuscleGroup = e.MuscleGroup.ToString(),
                            })
                            .AsNoTracking()
                            .ToListAsync();
        }

    }
}
