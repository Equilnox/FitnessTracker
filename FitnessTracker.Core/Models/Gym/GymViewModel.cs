using FitnessTracker.Core.Contracts;

namespace FitnessTracker.Core.Models.Gym
{
    /// <summary>
    /// Class is used for View Gyms.
    /// </summary>
    public class GymViewModel : IGymModel
    {
        /// <summary>
        /// Property for Gym Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for Gym Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Property for Gym Address.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Property for Gym Phone Number.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Property for Gym's Price Per Month.
        /// </summary>
        public string PricePerMonth { get; set; } = string.Empty;
    }
}
