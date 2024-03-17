using FitnessTracker.Core.Models.Gym;

namespace FitnessTracker.Core.Contracts
{
	public interface IGymService
    {
        /// <summary>
        /// Return all Gyms.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GymViewModel>> GetAllAsync();

        /// <summary>
        /// Return specific Gym.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GymDetailViewModel> GetGymAsync(int id);

        /// <summary>
        /// Return Athletes Memberships, who have joined the gym.
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        Task<IEnumerable<GymMembersViewModel>> GetMembersAsync(int gymId);
    }
}
