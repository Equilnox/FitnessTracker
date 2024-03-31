using FitnessTracker.Core.Models.Workout;

namespace FitnessTracker.Core.Contracts
{
	public interface IWorkoutService
	{
		Task<IEnumerable<GymToChooseViewModel>> GetGyms(int athleteId);

		Task<IEnumerable<ExerciseToChooseViewModel>> GetExercises();

		Task CreateWorkout(WorkoutFormModel model, int athleteId);

		List<WorkoutIntensitiesFormModel> AddExerciseToWorkout(WorkoutIntensitiesFormModel workoutIntensities);
	}
}
