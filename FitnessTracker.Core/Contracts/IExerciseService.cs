using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Infrastructure.Data.Models;

namespace FitnessTracker.Core.Contracts
{
	public interface IExerciseService
	{
		Task<IEnumerable<ExerciseViewModel>> GetAllAsync();

		Task<IEnumerable<ExerciseViewModel>> GetAllPerMuscleGroupAsync(int muscleGroup);

		Task<Exercise> FindExercise(int id);

		Task<ExerciseViewModel> FindAsync(int id);

		void AddNewAsync(ExerciseFormModel model);

		void SaveAsync();
	}
}
