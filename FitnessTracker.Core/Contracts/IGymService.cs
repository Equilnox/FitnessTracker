using FitnessTracker.Core.Models.Gym;

namespace FitnessTracker.Core.Contracts
{
	public interface IGymService
    {
        Task<IEnumerable<GymViewModel>> GetAllAsync();

        Task<GymDetailViewModel> GetGymAsync(int id);

        Task<IEnumerable<GymMembersViewModel>> GetMembersAsync(int gymId);
    }
}
