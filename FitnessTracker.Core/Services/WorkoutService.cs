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

		/// <summary>
		/// Method adds selected exercises to workout.
		/// </summary>
		/// <param name="workoutIntensities"></param>
		/// <returns></returns>
		public List<WorkoutIntensitiesFormModel> AddExerciseToWorkout(WorkoutIntensitiesFormModel workoutIntensities)
		{
			List<WorkoutIntensitiesFormModel> workoutData = new List<WorkoutIntensitiesFormModel>();

			workoutData.Add(workoutIntensities);

			return workoutData;
		}

		/// <summary>
		/// Method adds the workout to DB.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="athleteId"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Method to return exercises from witch the Athlete selects one to add to workout.
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Method returns all gyms that the Athlete has a membership in.
		/// </summary>
		/// <param name="athleteId"></param>
		/// <returns></returns>
		public async Task<IEnumerable<GymToChooseViewModel>> GetGyms(int athleteId)
		{
			var gyms = await repository.AllReadOnly<AthleteGym>()
				.Where(g => g.AthleteId == athleteId)
				.Select(g => new GymToChooseViewModel()
				{
					Id = g.Gym.Id,
					Name = g.Gym.Name
				})
				.ToListAsync();

			return gyms;
		}
	}
}
