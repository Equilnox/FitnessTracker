using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.Models.AthleteGym
{
    public class GymMembershipRenewFormModel
    {
        public int AthleteId { get; set; }

        public int GymId { get; set; }

        [Required]
        public string StartDate { get; set; } = string.Empty;

        [Required]
        public string EndDate { get; set; } = string.Empty;
    }
}
