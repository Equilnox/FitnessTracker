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

		/// <summary>
		/// Return all exercises, with tracking.
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<ExerciseViewModel>> GetAllAsync()
		{
			return await repository.AllReadOnly<Exercise>()
				.Where(e => e.IsApproved == true)
				.Select(e => new ExerciseViewModel
				{
					Id = e.Id,
					Name = e.Name,
					Description = e.Description,
					MuscleGroup = e.MuscleGroup.ToString(),
				})
				.ToListAsync();
		}

		/// <summary>
		/// Return all exercises for specific muscle group.
		/// </summary>
		/// <param name="_muscleGroup"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Return specific exercise, with tracking.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<Exercise> FindExerciseAsync(int id)
		{
			return await repository.All<Exercise>().FirstAsync(e => e.Id == id);
		}

		/// <summary>
		/// Return specific exercise, without tracking.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<ExerciseViewModel> FindExerciseAsNoTracingAsync(int id)
		{
			var exercise = await repository.AllReadOnly<Exercise>()
				.Select(e => new ExerciseViewModel
				{
					Id = e.Id,
					Name = e.Name,
					Description = e.Description,
					MuscleGroup = e.MuscleGroup.ToString(),
				})
				.AsNoTracking()
				.FirstAsync(e => e.Id == id);

			return exercise;
		}

		/// <summary>
		/// Add new exercise.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task AddNewAsync(ExerciseFormModel model)
		{
			var newExercise = new Exercise()
			{
                Name = model.Name,
                Description = model.Description,
                MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.MuscleGroup)
            };

			await repository.AddAsync(newExercise);
			await SaveAsync();
		}

		/// <summary>
		/// Save asynchronously new Exercise Entity.
		/// </summary>
		/// <returns></returns>
		public async Task SaveAsync()
		{
			await repository.SaveAsync();
		}
	}
}
