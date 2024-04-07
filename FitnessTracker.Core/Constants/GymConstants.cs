using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Core.Constants
{
	/// <summary>
	/// Static class to store default property values for Personal Gym when a new user is created.
	/// </summary>
	public static class GymConstants
	{
		/// <summary>
		/// Default value for Gym name.
		/// </summary>
		public const string PersonalGymName = "Personal gym";

		/// <summary>
		/// Default value for Gym address
		/// </summary>
		public const string PersonalGymAddress = "Home or Public Workout Spaces";

		/// <summary>
		/// Default value for Phone number
		/// </summary>
		public const string PersonalGymPhoneNumber = "0888000000";

		/// <summary>
		/// Default value for Price Per Month.
		/// </summary>
		public const decimal PersonalGymPricePerMonth = 0.00m;
	}
}
