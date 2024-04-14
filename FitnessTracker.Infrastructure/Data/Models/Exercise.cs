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
            "0 = Compound move; " +
            "1 = Chest muscles; " +
            "2 = Back muscles; " +
            "3 = Legs muscles; " +
            "4 = Arms muscles; " +
            "5 = Abdominal muscles.")]
        public MuscleGroup MuscleGroup { get; set; }

        public virtual ICollection<Intensity> Intensities { get; set; } = new List<Intensity>();

        public virtual ICollection<Requests> Requests { get; set; } = new List<Requests>();

        [Required]
        [Comment("A boolean check that represents if the Exercise is Approved by the admin. Default value is false. When value is set to true the Exercise is shown in the page.")]
        public bool IsApproved { get; set; } = false;
    }
}
