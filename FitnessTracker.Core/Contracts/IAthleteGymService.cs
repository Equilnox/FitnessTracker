using FitnessTracker.Core.Models.AthleteGym;

namespace FitnessTracker.Core.Contracts
{
    public interface IAthleteGymService
	{
		Task RenewAsync(GymMembershipRenewFormModel model);
	}
}
