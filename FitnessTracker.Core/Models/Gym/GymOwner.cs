namespace FitnessTracker.Core.Models.Gym
{
	/// <summary>
	/// Class is used for GymDetailsViewModel. It represents the User's Firs and Last Name whom is Owner of the Gym.
	/// </summary>
	public class GymOwner
	{
		/// <summary>
		/// Property for Gym Owner First Name.
		/// </summary>
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// Property for Gym Owner Last Name.
		/// </summary>
		public string LastName { get; set; } = string.Empty;
	}
}
