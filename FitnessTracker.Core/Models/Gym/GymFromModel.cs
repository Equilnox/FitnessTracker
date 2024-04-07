using FitnessTracker.Infrastructure.Data.Models.Enums;
using static FitnessTracker.Core.Constants.GymConstants;

namespace FitnessTracker.Core.Models.Gym
{
	/// <summary>
	/// Class is used to auto generate a new Personal gym for the athlete.
	/// </summary>
	public class GymFromModel
	{
		public string GymName { get; set; } = PersonalGymName;

		public string Address { get; set; } = PersonalGymAddress;

		public string OwnerId { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = PersonalGymPhoneNumber;

		public decimal PricePerMonth { get; set; } = PersonalGymPricePerMonth;

		public GymType GymType { get; set; } = GymType.Personal;
	}
}
