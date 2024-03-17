namespace FitnessTracker.Core.Models.Gym
{
    /// <summary>
    /// Class is used for Viewing Gym Members in Gym Details.
    /// </summary>
    public class GymMembersViewModel
    {
        /// <summary>
        /// Property for Athlete Id.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Property for Gym Id.
        /// </summary>
        public int GymId { get; set; }

        /// <summary>
        /// Property for Athlete Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Property for Athlete Height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Property for Athlete Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Property for Athlete's Membership Start Date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Property for Athlete's Membership End Date.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
