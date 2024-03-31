using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Workout
{
	public class WorkoutFormModel
	{
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int GymId { get; set; }

		[Required(ErrorMessage = RequiredFieldMessage)]
		public string WorkoutDate { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		public string WorkoutType { get; set; } = string.Empty;

		public IEnumerable<WorkoutIntensitiesFormModel> WorkoutIntensities { get; set; } = new List<WorkoutIntensitiesFormModel>();
	}
}
