using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Infrastructure.Data.Models
{
    [Comment("Intensity of a performed exercise.")]
    public class Intensity
    {
        [Key]
        [Comment("Intensity identifier.")]
        public int Id { get; set; }

        [Required]
        [Comment("The amount of weight with witch the exercise was performed.")]
        public int LiftedWeight { get; set; }

        [Required]
        [Comment("Number of repetition per set.")]
        public int Repetitions { get; set; }

        [Required]
        [Comment("Number of sets performed.")]
        public int Sets { get; set; }

        [Required]
        [Comment("The average amount of seconds elapsed for completing a single set")]
        public int Seconds { get; set; }

        [Required]
        [Comment("Exercise identifier.")]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        public Exercise Exercise { get; set; } = null!;

        [Required]
        [Comment("Workout identifier")]
        public int WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; } = null!;
    }
}
