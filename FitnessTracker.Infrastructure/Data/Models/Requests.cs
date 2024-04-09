using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Comment("Type of request. Can be Add Exercise = 0, Edit Exercise = 1")]
        public RequestType RequestType { get; set; }

        [Required]
        [Comment("Exercise identifier")]
        public int ExerciseId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        [Comment("Property for Exercise")]
        public Exercise Exercise { get; set; } = null!;

        [Comment("Property for Changing Exercise Name")]
        public string ExerciseNewName { get; set; } = string.Empty;

        [Comment("Property for Changing Exercise Description")]
        public string ExerciseNewDescription { get; set; } = string.Empty;

        [Required]
        [Comment("Request status. Can be Pending = 0, Done = 1 or Failed = 2")]
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
    }
}
