using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.AthleteGym
{
	public class NewMembershipFormModel
	{
		public int GymId { get; set; }

		[Display(Name =	"Athlete Email")]
		[Required(ErrorMessage = RequiredFieldMessage)]
		public string UserEmail { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		public string StartDate { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredFieldMessage)]
		public string EndDate { get; set; } = string.Empty;
	}
}
