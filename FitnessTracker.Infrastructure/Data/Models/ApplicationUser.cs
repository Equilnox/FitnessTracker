using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

namespace FitnessTracker.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
    }
}
