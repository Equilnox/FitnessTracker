using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Exercise
{
	public class ExerciseFormModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ExerciseNameMaxLength, MinimumLength = ExerciseNameMinLength, ErrorMessage = StringLengthMessage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(ExerciseDescriptionMaxLength, MinimumLength = ExerciseDescriptionMinLength, ErrorMessage = StringLengthMessage)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		public string MuscleGroup { get; set; } = string.Empty;
	}
}
