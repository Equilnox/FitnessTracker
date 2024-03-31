using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Workout;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Core.Services
{
	public class WorkoutService : IWorkoutService
	{
		private readonly IRepository repository;

		public WorkoutService(IRepository _repository)
		{
			repository = _repository;
		}

		public List<WorkoutIntensitiesFormModel> AddExerciseToWorkout(WorkoutIntensitiesFormModel workoutIntensities)
		{
			List<WorkoutIntensitiesFormModel> workoutData = new List<WorkoutIntensitiesFormModel>();

			workoutData.Add(workoutIntensities);

			return workoutData;
		}

		public async Task CreateWorkout(WorkoutFormModel model, int athleteId)
		{
			Workout workout = new Workout()
			{
				GymId = model.GymId,
				Date = DateTime.Parse(model.WorkoutDate),
				WorkoutType = (WorkoutType)Enum.Parse(typeof(WorkoutType), model.WorkoutType),
			};
			
			foreach(var intensityInModel in model.WorkoutIntensities)
			{
				var intensity = new Intensity()
				{
					ExerciseId = intensityInModel.ExerciseId,
					LiftedWeight = intensityInModel.LiftedWeight,
					Repetitions = intensityInModel.Repetitions,
					Seconds = intensityInModel.Seconds,
					Sets = intensityInModel.Sets
				};

				workout.Intensities.Add(intensity);
			}

			workout.AthleteId = athleteId;

			await repository.AddAsync(workout);
			await repository.SaveAsync();
		}

		public async Task<IEnumerable<ExerciseToChooseViewModel>> GetExercises()
		{
			return await repository.AllReadOnly<Exercise>()
				.Select(e => new ExerciseToChooseViewModel()
				{
					Id = e.Id,
					Name = e.Name
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<GymToChooseViewModel>> GetGyms(int athleteId)
		{
			return await repository.AllReadOnly<Gym>()
				.Select(g => new GymToChooseViewModel()
				{
					Id = g.Id,
					Name = g.Name
				})
				.ToListAsync();
		}
	}
}
