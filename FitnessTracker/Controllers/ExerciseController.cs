using FitnessTracker.Core.Models.ViewModels;
using FitnessTracker.Infrastructure.Data;
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

        public async Task<IActionResult> All()
        {
            var model = await data.Exercises
                .Select(e => new ExerciseViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    MuscleGroup = e.MuscleGroup.ToString(),
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }
    }
}
