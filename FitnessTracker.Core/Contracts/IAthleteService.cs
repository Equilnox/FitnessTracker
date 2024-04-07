using FitnessTracker.Core.Models.Athlete;
using FitnessTracker.Infrastructure.Data.Models;

namespace FitnessTracker.Core.Contracts
{
    public interface IAthleteService
    {
        /// <summary>
        /// Return athlete data.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<AthleteViewModel> GetAthlete(string UserId);

        /// <summary>
        /// Check if athlete exists.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<bool> ExistsById(string UserId);

        /// <summary>
        /// Return Athletes memberships.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<AthleteGymsViewModel>> GetGymMembershipsAsync(int id);

        /// <summary>
        /// Return Athlete workouts.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<AthleteWorkoutsViewModel>> GetAthleteWorkoutsAsync(int id);

        /// <summary>
        /// Return exercises for a workout.
        /// </summary>
        /// <param name="workoutIds"></param>
        /// <returns></returns>
        Task<IEnumerable<AthleteExerciseIntensity>> GetExercisesForWorkoutsAsync(IEnumerable<int> workoutIds);

        /// <summary>
        /// Create new Athlete entity after register.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddNewAthleteAsync(AthleteCreateFormModel model, string userId);

        /// <summary>
        /// Save asynchronously new Athlete Entity.
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();

        /// <summary>
        /// Returns Athlete details to be edited.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AthleteDetailsEditFormModel> FindByIdAsync(int id);

        /// <summary>
        /// Method that rewrite the data in athlete detail.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task EditDetailsAsync(AthleteDetailsEditFormModel model);

		/// <summary>
		/// Method to check if the current user and athlete are the same person.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="athleteId"></param>
		/// <returns></returns>
		Task<bool> CheckUserId(string userId, int athleteId);
	}
}
