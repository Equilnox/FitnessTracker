namespace FitnessTracker.Core.Models.Athlete
{
    /// <summary>
    /// Class is used to show Memberships of Athlete.
    /// </summary>
    public class AthleteGymsViewModel
    {
        /// <summary>
        /// Athlete identifier.
        /// </summary>
        public int AthleteId { get; set; }

        /// <summary>
        /// Gym identifier, for witch the Athlete is a Member.
        /// </summary>
        public int GymId { get; set; }

        /// <summary>
        /// Gym name.
        /// </summary>
        public string GymName { get; set; } = string.Empty;

        /// <summary>
        /// Start date of membership.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of membership.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
