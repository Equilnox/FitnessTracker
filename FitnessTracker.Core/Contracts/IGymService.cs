using FitnessTracker.Core.Models.Gym;

namespace FitnessTracker.Core.Contracts
{
	public interface IGymService
    {
        /// <summary>
        /// Return all Gyms that have there GymType property set to "Public".
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GymViewModel>> GetAllPublicAsync();

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

        /// <summary>
        /// Method returns Gym Owner First and Last Name by receiving User Id.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<GymOwner> GetOwnerName(string UserId);

        /// <summary>
        /// Method returns Gym Id by receiving User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetGymIdByUserIdAsync(string userId);

        /// <summary>
        /// Method saves changes to Data Basa.
        /// </summary>
        /// <returns></returns>
        Task SaveGymAsync();

        /// <summary>
        /// Method is used to change basic details for Gym.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> ChangeGymDetailsAsync(GymDetailsFormViewModel model);

        /// <summary>
        /// Method returns basic details of Gym.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GymDetailsFormViewModel> GetGymDetailsAsync(int id);

        
    }
}
