using FitnessTracker.Core.Models.AthleteGym;

namespace FitnessTracker.Core.Contracts
{
    public interface IAthleteGymService
	{
		/// <summary>
		/// Update the Start and End date for athlete membership.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task RenewAsync(GymMembershipRenewFormModel model);

		/// <summary>
		/// Create new Athlete membership.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="athleteId"></param>
		/// <returns></returns>
		Task AddNewMember(NewMembershipFormModel model, int athleteId);

		/// <summary>
		/// Performs a Check if Athlete is Registered.
		/// </summary>
		/// <param name="userEmail"></param>
		/// <returns></returns>
		Task<bool> AthleteExists(string userEmail);

		/// <summary>
		/// Return Athlete's Id. If there are more then one Athlete with the Same Email returns 0.
		/// </summary>
		/// <param name="userEmail"></param>
		/// <returns></returns>
		Task<int> GetAthleteId(string userEmail);

		Task<bool> AthleteIsMember(int athleteId, int gymId);
	}
}
