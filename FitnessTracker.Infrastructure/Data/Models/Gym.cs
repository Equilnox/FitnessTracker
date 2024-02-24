using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

namespace FitnessTracker.Infrastructure.Data.Models
{
    [Comment("Available gym")]
    public class Gym
    {
        [Key]
        [Comment("Gym identifier.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GymNameMaxLength)]
        [Comment("Gym name.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength()]
        [Comment("Gym address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(GymOwnerMaxLength)]
        [Comment("Gym owner full name.")]
        public string Owner { get; set; } = string.Empty;

        [Required]
        [MaxLength(GymPhoneNumberMaxLength)]
        [Comment("Gym phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Gym membership price per month")]
        public decimal PricePerMonth { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();

        public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

        public virtual ICollection<AthleteGym> AthletesGyms { get; set; } = new List<AthleteGym>();
    }
}
