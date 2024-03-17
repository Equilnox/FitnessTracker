using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.AthleteGym
{
	/// <summary>
	/// Class is used for Adding New Member for Gym.
	/// </summary>
	public class NewMembershipFormModel
	{
		/// <summary>
		/// Property for Gym Identifier.
		/// </summary>
		public int GymId { get; set; }

		/// <summary>
		/// Property for User Email.
		/// </summary>
		[Display(Name =	"Athlete Email")]
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string UserEmail { get; set; } = string.Empty;

		/// <summary>
		/// Property for Start Date of membership.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string StartDate { get; set; } = string.Empty;

		/// <summary>
		/// Property for End Date of Membership.
		/// </summary>
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string EndDate { get; set; } = string.Empty;
	}
}
