using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Infrastructure.Data.Models
{
    public class Requests
    {
        [Key]
        [Comment("Request identifier")]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("The date the request was made. Default value is 'DateTime.Now'")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Comment("The date the request was processed")]
        public DateTime? DateDone { get; set; }

        [Required]
        [MaxLength(RequestTypeMaxLength)]
        [Comment("Type of request. Can be Add Exercise = 0, Edit Exercise = 1")]
        public string RequestType { get; set; } = string.Empty;

        [Required]
        [Comment("Exercise identifier")]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        [Comment("Property for Exercise")]
        public Exercise Exercise { get; set; } = null!;

        [MaxLength(ExerciseNameMaxLength)]
        [Comment("Property for Changing Exercise Name")]
        public string ExerciseNewName { get; set; } = string.Empty;

        [MaxLength(ExerciseDescriptionMaxLength)]
        [Comment("Property for Changing Exercise Description")]
        public string ExerciseNewDescription { get; set; } = string.Empty;

        [Comment("Property for changing exercise targeted muscle group")]
        public MuscleGroup ChangeMuscleGroup { get; set; }

        [Required]
        [MaxLength(RequestStatusMaxLength)]
        [Comment("Request status. Can be Pending = 0 or Done = 1")]
        public string RequestStatus { get; set; } = string.Empty;
    }
}
