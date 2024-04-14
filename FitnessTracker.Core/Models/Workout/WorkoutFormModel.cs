using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Workout
{
	/// <summary>
	/// Class is used to add Workouts to Athlete
	/// </summary>
	public class WorkoutFormModel
	{
		/// <summary>
		/// Gym Identifier
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int GymId { get; set; }

		/// <summary>
		/// Workout Date when the 
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string WorkoutDate { get; set; } = string.Empty;

		/// <summary>
		/// Workout Type
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string WorkoutType { get; set; } = string.Empty;

		/// <summary>
		/// Collection of selected exercises during the Workout.
		/// </summary>
		public IEnumerable<WorkoutIntensitiesFormModel> WorkoutIntensities { get; set; } = new List<WorkoutIntensitiesFormModel>();
	}
}
