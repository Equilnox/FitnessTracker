using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Workout
{
	public class WorkoutIntensitiesFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string ExerciseMuscleGroup { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		public int ExerciseId { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		public int LiftedWeight { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Repetitions { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Sets { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Seconds { get; set; }
	}
}
