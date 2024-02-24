using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

namespace FitnessTracker.Infrastructure.Data.Models
{
    [Comment("Performed workout.")]
    public class Workout
    {
        [Key]
        [Comment("Workout identifier.")]
        public int Id { get; set; }

        [Required]
        [Comment("Workout type. Can be one of following: " +
            "1 = Full Body; " +
            "2 = Chest workout; " +
            "3 = Back workout; " +
            "4 = Legs workout; " +
            "5 = Arms workout; " +
            "6 = Abdominal workout; " +
            "7 = HIIT workout.")]
        public WorkoutType WorkoutType { get; set; }

        [Required]
        [Comment("The day of the workout")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("User identifier")]
        public int AthleteId { get; set; }

        [ForeignKey(nameof(AthleteId))]
        public Athlete Athlete { get; set; } = null!;

        [Required]
        [Comment("Gym identifier")]
        public int GymId { get; set; }

        [ForeignKey(nameof(GymId))]
        public Gym Gym { get; set; } = null!;

        public virtual ICollection<Intensity> Intensities { get; set; } = new List<Intensity>();
    }
}
