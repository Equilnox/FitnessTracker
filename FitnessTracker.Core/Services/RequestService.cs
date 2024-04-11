using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Request;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Core.Services
{
	public class RequestService : IRequestService
    {
        private readonly IRepository repository;

        public RequestService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddExerciseAsync(AddExerciseFormModel model, string userId)
        {
            var newRequest = new Requests()
            {
                UserId = userId,
                Exercise = new Exercise()
                {
                    Name = model.Name,
                    Description = model.Description,
                    MuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.MuscleGroup)
                },
                RequestType = RequestType.AddExercise.ToString(),
                RequestStatus = RequestStatus.Pending.ToString()
            };

            await repository.AddAsync(newRequest);
            await repository.SaveAsync();
        }

        public async Task ApproveChangesAsync(int id)
        {
            var request = await repository.All<Requests>()
                .FirstAsync(r => r.Id == id);

            request.DateDone = DateTime.Now;
            request.RequestStatus = RequestStatus.Done.ToString();
            request.Exercise.Name = request.ExerciseNewName;
            request.Exercise.Description = request.ExerciseNewDescription;

            await repository.SaveAsync();
        }

        public async Task ApproveExerciseAsync(int id)
        {
            var requests = await repository.All<Requests>()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (requests != null)
            {
                requests.RequestStatus = RequestStatus.Done.ToString();
                requests.DateDone = DateTime.Now;
                requests.Exercise.IsApproved = true;
                await repository.SaveAsync();
            }
        }

        public async Task EditExerciseAsync(EditExerciseFormModel model, string userId)
        {
            Exercise exercise = await repository.All<Exercise>()
                .FirstAsync(e => e.Id == model.Id);

            if (string.IsNullOrEmpty(model.NewName))
            {
                model.NewName = exercise.Name;
            }

            if (string.IsNullOrEmpty(model.NewDescription))
            {
                model.NewDescription = exercise.Description;
            }

            var newRequest = new Requests()
            {
                UserId = userId,
                Exercise = exercise,
                ExerciseNewName = model.NewName,
                ExerciseNewDescription = model.NewDescription,
                RequestType = RequestType.EditExercise.ToString()
            };

            await repository.AddAsync(newRequest);
            await repository.SaveAsync();
        }

		public async Task<IEnumerable<SubmittedRequestViewModel>> GetDoneRequestsAsync()
		{
			return await repository.AllReadOnly<Requests>()
				.Where(r => r.RequestStatus == RequestStatus.Done.ToString())
				.Select(r => new SubmittedRequestViewModel()
				{
					Id = r.Id,
					DateCreated = r.DateCreated.ToShortDateString(),
					UserEmail = r.User.Email,
					ExerciseName = r.Exercise.Name,
					ExerciseDescription = r.Exercise.Description,
					ExerciseNewName = r.ExerciseNewName,
					ExerciseNewDescription = r.ExerciseNewDescription,
					RequestType = r.RequestType.ToString()
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<SubmittedRequestViewModel>> GetPendingRequestsAsync()
        {
            return await repository.AllReadOnly<Requests>()
                .Where(r => r.RequestStatus == RequestStatus.Pending.ToString())
                .Select(r => new SubmittedRequestViewModel()
                {
                    Id = r.Id,
                    DateCreated = r.DateCreated.ToShortDateString(),
                    UserEmail = r.User.Email,
                    ExerciseName = r.Exercise.Name,
                    ExerciseDescription = r.Exercise.Description,
                    ExerciseNewName = r.ExerciseNewName,
                    ExerciseNewDescription = r.ExerciseNewDescription,
                    RequestType = r.RequestType.ToString()
                })
                .ToListAsync();
        }

        public async Task<SubmittedRequestViewModel> GetRequestsAsync(int id)
        {
            return await repository.All<Requests>()
                .Where(r => r.RequestStatus == RequestStatus.Pending.ToString())
                .Select(r => new SubmittedRequestViewModel()
                {
                    Id = r.Id,
                    DateCreated = r.DateCreated.ToShortDateString(),
                    UserEmail = r.User.Email,
                    ExerciseName = r.Exercise.Name,
                    ExerciseDescription = r.Exercise.Description,
                    RequestType = r.RequestType.ToString(),
                    ExerciseNewName = r.ExerciseNewName,
                    ExerciseNewDescription = r.ExerciseNewDescription
                })
                .FirstAsync(r => r.Id == id);
        }
    }
}
