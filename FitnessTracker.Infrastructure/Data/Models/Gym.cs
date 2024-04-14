using FitnessTracker.Infrastructure.Data.Models.Enums;
using FitnessTracker.Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity;
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
        [MaxLength(GymAddressMaxLength)]
        [Comment("Gym address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserIdMaxLength)]
        [Comment("Gym owner Identifier.")]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public ApplicationUser Owner { get; set; } = null!;

        [Required]
        [MaxLength(GymPhoneNumberMaxLength)]
        [Comment("Gym phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Gym membership price per month")]
        public decimal PricePerMonth { get; set; }

        [Required]
		[Comment("Gym type. Can be one of following: " +
			"0 = Personal; " +
			"1 = Public.")]
		public GymType GymType { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();

        public virtual ICollection<AthleteGym> AthletesGyms { get; set; } = new List<AthleteGym>();
    }
}
