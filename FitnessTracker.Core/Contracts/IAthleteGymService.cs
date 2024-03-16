using FitnessTracker.Core.Models.AthleteGym;

namespace FitnessTracker.Core.Contracts
{
    public interface IAthleteGymService
	{
		Task RenewAsync(GymMembershipRenewFormModel model);

		Task AddNewMember(NewMembershipFormModel model, int athleteId);

		Task<bool> AthleteExists(string userEmail);

		Task<int> GetAthleteId(string userEmail);
	}
}
