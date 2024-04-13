using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Extensions;
using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService service;

        public ExerciseController(IExerciseService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<ExerciseViewModel> model = await service.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PerMuscleGroup(int _muscleGroup)
		{
			if (!Enum.IsDefined(typeof(MuscleGroup), _muscleGroup))
			{
				return RedirectToAction(nameof(All));
			}

			var model = await service.GetAllPerMuscleGroupAsync(_muscleGroup);

			return View(model.ToList());
		}

        [HttpGet]
		public async Task<IActionResult> Details(int id, string information)
        {
            if(await service.ExerciseExists(id) == false)
            {
                return BadRequest();
            }

			var model = await service.FindExerciseAsNoTracingAsync(id);

            if(information != model.GetExerciseInformation())
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
