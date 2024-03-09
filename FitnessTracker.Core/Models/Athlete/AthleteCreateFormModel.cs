using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Athlete
{
    public class AthleteCreateFormModel
    {
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength, ErrorMessage = StringLengthMessage)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength, ErrorMessage = StringLengthMessage)]
        public string LastName { get; set; } = string.Empty;
    }
}
