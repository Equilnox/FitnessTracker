namespace FitnessTracker.Core.Models.Workout
{
	/// <summary>
	/// Class is used to select where the workout happened, when creating a new workout.
	/// </summary>
	public class GymToChooseViewModel
	{
		/// <summary>
		/// Gym identifier
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gym Name
		/// </summary>
		public string Name { get; set; } = string.Empty;
	}
}
