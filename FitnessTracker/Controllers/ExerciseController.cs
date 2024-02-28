using FitnessTracker.Core.Models.ViewModels;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Details(string name)
        {
            var exerciseList = await GetAllExercises();

            var model = exerciseList.FirstOrDefault(e => e.Name == name);

            return View(model);
        }

        private async Task<List<ExerciseViewModel>> GetAllExercises()
        {
            return await data.Exercises
                            .Select(e => new ExerciseViewModel
                            {
                                Name = e.Name,
                                Description = e.Description,
                                MuscleGroup = e.MuscleGroup.ToString(),
                            })
                            .AsNoTracking()
                            .ToListAsync();
        }

    }
}
