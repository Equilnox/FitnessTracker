using FitnessTracker.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Athlete
{
	/// <summary>
	/// Class used for Edit View.
	/// </summary>
	public class AthleteDetailsEditFormModel : IAthleteModel
	{
		/// <summary>
		/// Property for Athlete Identifier.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Property for Athlete First Name.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength, ErrorMessage = StringLengthMessage)]
		[Display(Name = "First name")]
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// Property for Athlete Last Name.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		[StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength, ErrorMessage = StringLengthMessage)]
		[Display(Name = "Last name")]
		public string LastName { get; set; } = string.Empty;

		/// <summary>
		/// Property for Athlete Age.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Age { get; set; }

		/// <summary>
		/// Property for Athlete's Weight.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public double Weight { get; set; }

		/// <summary>
		/// Property for Athlete Hight.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public int Height { get; set; }
	}
}
