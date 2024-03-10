using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Infrastructure.Data.Models;

namespace FitnessTracker.Core.Contracts
{
    public interface IGymService
    {
        Task<IEnumerable<GymViewModel>> GetAllAsync();

        Task<GymDetailViewModel> GetGymAsync(int id);

        Task<IEnumerable<GymMembersViewModel>> GetMembersAsync(int gymId);

        Task RenewAsync(GymMembershipRenewFormModel model);
    }
}
