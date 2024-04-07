using FitnessTracker.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Gym
{
	/// <summary>
	/// Class is used to Edit Gym Details.
	/// </summary>
	public class GymDetailsFormViewModel
    {
        /// <summary>
        /// Property for Gym Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for Gym Name.
        /// </summary>
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(GymNameMaxLength, MinimumLength = GymNameMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Gym name")]
        public string GymName { get; set; } = string.Empty;

        /// <summary>
        /// Property for Gym Address.
        /// </summary>
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(GymAddressMaxLength, MinimumLength = GymAddressMinLength, ErrorMessage = StringLengthMessage)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Property for Gym Phone Number.
        /// </summary>
        [Required(ErrorMessage = RequiredFieldMessage)]
        [StringLength(GymPhoneNumberMaxLength, MinimumLength = GymPhoneNumberMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// Property for Gym Price Per Month.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
        [Range(typeof(decimal), "0.00", GymMaxPricePerMonth, ErrorMessage = GymPriceRange)]
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }
    }
}
