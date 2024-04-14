using FitnessTracker.Core.Models.Workout;

namespace FitnessTracker.Core.Contracts
{
	public interface IWorkoutService
	{
		/// <summary>
		/// Method returns all gyms that the Athlete has a membership in.
		/// </summary>
		/// <param name="athleteId"></param>
		/// <returns></returns>
		Task<IEnumerable<GymToChooseViewModel>> GetGyms(int athleteId);

		/// <summary>
		/// Method to return exercises from witch the Athlete selects one to add to workout.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ExerciseToChooseViewModel>> GetExercises();

		/// <summary>
		/// Method adds the workout to DB.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="athleteId"></param>
		/// <returns></returns>
		Task CreateWorkout(WorkoutFormModel model, int athleteId);

		/// <summary>
		/// Method adds selected exercises to workout.
		/// </summary>
		/// <param name="workoutIntensities"></param>
		/// <returns></returns>
		List<WorkoutIntensitiesFormModel> AddExerciseToWorkout(WorkoutIntensitiesFormModel workoutIntensities);
	}
}
