using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Models.AthleteGym
{
    /// <summary>
    /// Class is used to Renew a membership of an Athlete.
    /// </summary>
    public class GymMembershipRenewFormModel
    {
        /// <summary>
        /// Property for Athlete Identifier.
        /// </summary>
        public int AthleteId { get; set; }

        /// <summary>
        /// Property for Gym Identifier.
        /// </summary>
        public int GymId { get; set; }

        /// <summary>
        /// Property for Start Date of membership.
        /// </summary>
        [Required]
        public string StartDate { get; set; } = string.Empty;

        /// <summary>
        /// Property for End Date of membership.
        /// </summary>
        [Required]
        public string EndDate { get; set; } = string.Empty;
    }
}
