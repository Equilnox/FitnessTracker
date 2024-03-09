using FitnessTracker.Core.Models.Athlete;

namespace FitnessTracker.Core.Contracts
{
    public interface IAthleteService
    {
        Task<AthleteViewModel> GetAthlete(string UserId);

        Task<bool> ExistsById(string UserId);

        Task<IEnumerable<AthleteGymsViewModel>> GetGymMembershipsAsync(int id);

        Task<IEnumerable<AthleteWorkoutsViewModel>> GetAthleteWorkoutsAsync(int id);

        Task<IEnumerable<AthleteExerciseIntensity>> GetExercisesForWorkoutsAsync(IEnumerable<int> workoutIds);

        void AddNewAthleteAsync(AthleteCreateFormModel model, string userId);
    }
}
