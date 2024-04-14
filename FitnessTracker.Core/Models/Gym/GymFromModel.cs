using FitnessTracker.Infrastructure.Data.Models.Enums;
using static FitnessTracker.Core.Constants.GymConstants;

namespace FitnessTracker.Core.Models.Gym
{
	/// <summary>
	/// Class is used to auto generate a new Personal gym for the athlete.
	/// </summary>
	public class GymFromModel
	{
		/// <summary>
		/// Gym Name. The property has a default value = "Personal gym".
		/// </summary>
		public string GymName { get; set; } = PersonalGymName;

		/// <summary>
		/// Gym Address. The property has a default value = "Home or Public Workout Spaces"
		/// </summary>
		public string Address { get; set; } = PersonalGymAddress;

		/// <summary>
		/// Owner Identifier. Default value is and empty string, but when a new user is created it is set to new users Identifier.
		/// </summary>
		public string OwnerId { get; set; } = string.Empty;

		/// <summary>
		/// Owner Phone Number. Property has default value = 0888000000
		/// </summary>
		public string PhoneNumber { get; set; } = PersonalGymPhoneNumber;

		/// <summary>
		/// Price per month. Property has default value = 0.00.
		/// </summary>
		public decimal PricePerMonth { get; set; } = PersonalGymPricePerMonth;

		/// <summary>
		/// Gym Type. Property has default value = Personal.
		/// </summary>
		public GymType GymType { get; set; } = GymType.Personal;
	}
}
