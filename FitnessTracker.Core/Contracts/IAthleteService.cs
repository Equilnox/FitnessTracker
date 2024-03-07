using FitnessTracker.Core.Models.Athlete;

namespace FitnessTracker.Core.Contracts
{
    public interface IAthleteService
    {
        Task<AthleteViewModel> GetAthlete(string UserId);

        Task<bool> ExistsById(string UserId);
    }
}
