using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Infrastructure.Data.Models;

namespace FitnessTracker.Core.Contracts
{
	public interface IExerciseService
	{
		/// <summary>
		/// Return all exercises, with tracking.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ExerciseViewModel>> GetAllAsync();

		/// <summary>
		/// Return all exercises for specific muscle group.
		/// </summary>
		/// <param name="muscleGroup"></param>
		/// <returns></returns>
		Task<IEnumerable<ExerciseViewModel>> GetAllPerMuscleGroupAsync(int muscleGroup);

		/// <summary>
		/// Return specific exercise, with tracking.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Exercise> FindExerciseAsync(int id);

		/// <summary>
		/// Return specific exercise, without tracking.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ExerciseViewModel> FindExerciseAsNoTracingAsync(int id);

		/// <summary>
		/// Add new exercise.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task AddNewAsync(ExerciseFormModel model);

		/// <summary>
		/// Save asynchronously new Exercise Entity.
		/// </summary>
		/// <returns></returns>
		Task SaveAsync();
	}
}
