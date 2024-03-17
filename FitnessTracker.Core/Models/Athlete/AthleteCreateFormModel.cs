using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Athlete
{
    /// <summary>
    /// Class is used when a new user registers.
    /// </summary>
    public class AthleteCreateFormModel
    {
        /// <summary>
        /// Athlete First name property.
        /// </summary>
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength, ErrorMessage = StringLengthMessage)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Athlete Last name property.
        /// </summary>
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength, ErrorMessage = StringLengthMessage)]
        public string LastName { get; set; } = string.Empty;
    }
}
