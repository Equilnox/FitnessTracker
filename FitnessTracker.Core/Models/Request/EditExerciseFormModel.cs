using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

namespace FitnessTracker.Core.Models.Request
{
	public class EditExerciseFormModel
	{
		public int Id { get; set; }

		[Display(Name = "Exercise Name")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Exercise Description")]
		public string Description { get; set; } = string.Empty;

		[Display(Name = "Targeted muscle group")]
		public string MuscleGroup { get; set; } = string.Empty;

		[Required]
		[StringLength(ExerciseNameMaxLength)]
		[Display(Name = "Exercise New Name")]
		public string NewName { get; set; } = string.Empty;

		[Required]
		[StringLength(ExerciseDescriptionMaxLength)]
		[Display(Name = "Exercise New Description")]
		public string NewDescription { get; set; } = string.Empty;


        [Display(Name = "Targeted muscle group")]
        public string ChangeMuscleGroup { get; set; } = string.Empty;
    }
}
