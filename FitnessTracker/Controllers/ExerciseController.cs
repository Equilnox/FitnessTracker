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
            List<ExerciseViewModel> model = await GetAllExercises();

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

            var all = await GetAllExercises();

            var model = all.Where(ms => ms.MuscleGroup == muscleGroup).ToList();

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var exerciseList = await GetAllExercises();

            var model = exerciseList.FirstOrDefault(e => e.Id == id);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateExercise()
        {
            var model = new ExerciseFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise(ExerciseFormModel model)
        {
            var modelName = model.Name.Count();
            var modelDescription = model.Description.Count();

            if (!ModelState.IsValid)
            {
                model = new ExerciseFormModel();

                return View(model);
            }

            var newExercise = new Exercise()
            {
                Name = model.Name,
                Description = model.Description,
				MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.MuscleGroup)
            };

            await data.AddAsync(newExercise);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = newExercise.Id });
        }

        private async Task<List<ExerciseViewModel>> GetAllExercises()
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
