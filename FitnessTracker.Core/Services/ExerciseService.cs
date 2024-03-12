using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Core.Services
{
	public class ExerciseService : IExerciseService
	{
		private readonly IRepository repository;

		public ExerciseService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<ExerciseViewModel>> GetAllAsync()
		{
			return await repository.AllReadOnly<Exercise>()
				.Select(e => new ExerciseViewModel
				{
					Id = e.Id,
					Name = e.Name,
					Description = e.Description,
					MuscleGroup = e.MuscleGroup.ToString(),
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<ExerciseViewModel>> GetAllPerMuscleGroupAsync(int _muscleGroup)
		{
			var specifiedMuscleGroup = (MuscleGroup)_muscleGroup;

			var muscleGroup = specifiedMuscleGroup.ToString();

			var exercises = await repository.AllReadOnly<Exercise>()
				.Select(e => new ExerciseViewModel
				{
					Id = e.Id,
					Name = e.Name,
					Description = e.Description,
					MuscleGroup = e.MuscleGroup.ToString()
				})
				.ToListAsync();

			var exercisesPerMuscleGroup = exercises.Where(e => e.MuscleGroup == muscleGroup);

			return exercisesPerMuscleGroup;
		}

		public async Task<Exercise> FindExerciseAsync(int id)
		{
			return await repository.All<Exercise>().FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<ExerciseViewModel> FindExerciseAsNotracingAsync(int id)
		{
			var exercises = await GetAllAsync();

			var exercise = exercises.FirstOrDefault(e => e.Id == id);

			return exercise;
		}

		public async Task AddNewAsync(ExerciseFormModel model)
		{
			var newExercise = new Exercise()
			{
				Name = model.Name,
				Description = model.Description,
				MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.MuscleGroup)
			};

			repository.AddAsync(newExercise);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			repository.SaveAsync();
		}
	}
}
