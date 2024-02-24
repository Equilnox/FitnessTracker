using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

namespace FitnessTracker.Infrastructure.Data.Models
{
    [Comment("Exercises.")]
    public class Exercise
    {
        [Key]
        [Comment("Exercise identifier.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        [Comment("Exercise name.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ExerciseDescriptionMaxLength)]
        [Comment("Exercise description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Exercise targeted muscle. Can be one of following: " +
            "1 = Compound move; " +
            "2 = Chest muscles; " +
            "3 = Back muscles; " +
            "4 = Legs muscles; " +
            "5 = Arms muscles; " +
            "6 = Abdominal muscles.")]
        public MuscleGroup MuscleGroup { get; set; }

        public virtual ICollection<Intensity> Intensities { get; set; } = new List<Intensity>();
    }
}
