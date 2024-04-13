using FitnessTracker.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Models.Request
{
    public class SubmittedRequestViewModel : IRequestModel
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

		[Display(Name = "Exercise muscle group")]
		public string ExerciseMuscleGroup { get; set; } = string.Empty;

		[Display(Name = "Suggested new name")]
		public string ExerciseNewName { get; set; } = string.Empty;

		[Display(Name = "Suggested new description")]
		public string ExerciseNewDescription { get; set; } = string.Empty;

		[Display(Name = "Suggested change for muscle group")]
		public string ChaneMuscleGroup { get; set; } = string.Empty;

		public string? DateApproved { get; set; }

		public string RequestStatus { get; set; } = string.Empty;
	}
}
