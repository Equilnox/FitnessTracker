using FitnessTracker.Core.Models.Athlete;

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
    }
}
