using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Models.Request
{
	public class SubmittedRequestViewModel
	{
		public int Id { get; set; }

		[Display(Name = "User Email")]
		public string UserEmail { get; set; } = string.Empty;

		[Display(Name = "Date created")]
		public string DateCreated { get; set; } = string.Empty;

		public string RequestType { get; set; } = string.Empty;

		[Display(Name = "Exercise name")]
		public string ExerciseName { get; set; } = string.Empty;

		[Display(Name = "Exercise description")]
		public string ExerciseDescription { get; set; } = string.Empty;

		[Display(Name = "Suggested new name")]
		public string ExerciseNewName { get; set; } = string.Empty;

		[Display(Name = "Suggested new description")]
		public string ExerciseNewDescription { get; set; } = string.Empty;
	}
}
