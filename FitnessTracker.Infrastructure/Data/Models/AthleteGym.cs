using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Infrastructure.Data.Models
{
    public class AthleteGym
    {
        [Required]
        [Comment("Athlete identifier")]
        public int AthleteId { get; set; }

        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;

        [Required]
        [Comment("Gym identifier")]
        public int GymId { get; set; }

        [ForeignKey(nameof(GymId))]
        public Gym Gym { get; set; } = null!;


        [Required]
        [Comment("Start date od membership")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("End date of membership")]
        public DateTime EndDate { get; set; }
    }
}
