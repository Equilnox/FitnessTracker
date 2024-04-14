using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Exercise
{
	/// <summary>
	/// Class is used For Adding new Exercises.
	/// </summary>
	public class ExerciseFormModel
	{
		/// <summary>
		/// Property for Exercise Name.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ExerciseNameMaxLength, MinimumLength = ExerciseNameMinLength, ErrorMessage = StringLengthMessage)]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Property for Exercise Description.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ExerciseDescriptionMaxLength, MinimumLength = ExerciseDescriptionMinLength, ErrorMessage = StringLengthMessage)]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// Property for Exercise Muscle Group to witch it belongs.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string MuscleGroup { get; set; } = string.Empty;
	}
}
