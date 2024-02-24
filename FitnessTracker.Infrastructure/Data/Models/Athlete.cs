using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

namespace FitnessTracker.Infrastructure.Data.Models
{
    [Comment("Additional information of the user.")]
    public class Athlete
    {
        [Key]
        [Comment("User identifier.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("User first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [Comment("User last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Comment("User profile picture")]
        public string ProfilePictureURL { get; set; } = string.Empty;

        [Required]
        [Comment("User age.")]
        public int Age { get; set; }

        [Required]
        [Comment("User height.")]
        public int Height { get; set; }

        [Required]
        [Comment("User weight.")]
        public double Weight { get; set; }

        [Required]
        [MaxLength(UserIdMaxLength)]
        [Comment("User identifier.")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();

        public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

        public virtual ICollection<AthleteGym> AthletesGym { get; set; } = new List<AthleteGym>();
    }
}
