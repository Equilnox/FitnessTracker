using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Workout
{
	/// <summary>
	/// Class is used to add Exercises to Workout.
	/// </summary>
	public class WorkoutIntensitiesFormModel
	{
		/// <summary>
		/// Exercise targeted muscle group.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string ExerciseMuscleGroup { get; set; } = string.Empty;

		/// <summary>
		/// Exercise Identifier
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int ExerciseId { get; set; }

		/// <summary>
		/// Amount of Lifted weight used for performing the exercise
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int LiftedWeight { get; set; }

		/// <summary>
		/// Amount of repetitions performed of the exercise
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Repetitions { get; set; }

		/// <summary>
		/// Amount of performed sets for the exercise during the workout
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Sets { get; set; }

		/// <summary>
		/// Amount of average time spent per set
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Seconds { get; set; }
	}
}
