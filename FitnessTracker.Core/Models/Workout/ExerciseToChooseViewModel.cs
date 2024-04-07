namespace FitnessTracker.Core.Models.Workout
{
	/// <summary>
	/// Class is used to select the Exercise for the new Workout.
	/// </summary>
	public class ExerciseToChooseViewModel
	{
		/// <summary>
		/// Exercise Identifier
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Exercise Name
		/// </summary>
		public string Name { get; set; } = string.Empty;
	}
}
