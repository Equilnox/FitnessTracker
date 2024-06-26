﻿using FitnessTracker.Core.Models.Request;

namespace FitnessTracker.Core.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<SubmittedRequestViewModel>> GetPendingRequestsAsync();

        Task<IEnumerable<SubmittedRequestViewModel>> GetDoneRequestsAsync();

        Task<IEnumerable<SubmittedRequestViewModel>> GetDismissedRequestsAsync();

        Task<SubmittedRequestViewModel> GetRequestsAsync(int id);

        Task AddExerciseAsync(AddExerciseFormModel model, string userId);

        Task EditExerciseAsync(EditExerciseFormModel model, string userId);

        Task ApproveExerciseAsync(int id);

        Task ApproveChangesAsync(int id);

        Task Dismiss(int id);

        Task<bool> RequestExistsAsync(int id);
    }
}
