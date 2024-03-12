using FitnessTracker.Core.Models.Gym;

namespace FitnessTracker.Core.Contracts
{
	public interface IAthleteGymService
	{
		Task RenewAsync(GymMembershipRenewFormModel model);
	}
}
