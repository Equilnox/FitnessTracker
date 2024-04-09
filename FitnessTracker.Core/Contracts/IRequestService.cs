using FitnessTracker.Core.Models.Request;

namespace FitnessTracker.Core.Contracts
{
    public interface IRequestService
    {
        Task AddExerciseAsync(AddExerciseFormModel model, string userId);

        Task EditExerciseAsync(EditExerciseFormModel model, string userId);

        Task ApproveExerciseAsync(int id);

        Task ApproveChangesAsync(int id);
    }
}
