using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Extensions;
using FitnessTracker.Infrastructure.Data.Models;
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

		public async Task<IActionResult> Details(int id)
        {
			var model = await service.FindExerciseAsNoTracingAsync(id);

            if(model == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

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

			await service.AddNewAsync(model);

			return RedirectToAction(nameof(All));
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			var exerciseToEdit = await service.FindExerciseAsync(id);

            if (exerciseToEdit == null)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
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
			Exercise? editedExercise = await service.FindExerciseAsync(model.Id);

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

			await service.SaveAsync();

			return RedirectToAction(nameof(Details), new { id = editedExercise.Id });
		}
    }
}
