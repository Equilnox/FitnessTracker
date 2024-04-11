using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Request;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using static FitnessTracker.Infrastructure.Data.Constrains.DataConstrains;

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
                ExerciseName = model.Name,
                ExerciseDescription = model.Description,
                MuscleGroupe = model.MuscleGroup,
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
                .Include(x => x.Exercise)
                .FirstAsync(r => r.Id == id);

            request.DateDone = DateTime.Now;
            request.RequestStatus = RequestStatus.Done.ToString();
            request.Exercise.Name = request.ExerciseNewName;
            request.Exercise.Description = request.ExerciseNewDescription;
            request.Exercise.MuscleGroup = request.ChangeMuscleGroup;

            await repository.SaveAsync();
        }

        public async Task ApproveExerciseAsync(int id)
        {
            var requests = await repository.All<Requests>()
                .Include(e => e.Exercise)
                .FirstOrDefaultAsync(r => r.Id == id);

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

            var newRequest = new Requests()
            {
                UserId = userId,
                Exercise = exercise,
                ExerciseName = model.Name,
                ExerciseDescription = model.Description,
                MuscleGroupe = model.MuscleGroup,
                ExerciseNewName = model.NewName,
                ExerciseNewDescription = model.NewDescription,
                ChangeMuscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), model.ChangeMuscleGroup),
                RequestType = RequestType.EditExercise.ToString(),
                RequestStatus = RequestStatus.Pending.ToString()
            };

            await repository.AddAsync(newRequest);
            await repository.SaveAsync();
        }

		public async Task<IEnumerable<SubmittedRequestViewModel>> GetDoneRequestsAsync()
		{
			return await repository.AllReadOnly<Requests>()
				.Where(r => r.RequestStatus == RequestStatus.Done.ToString())
                .OrderByDescending(r => r.DateDone)
				.Select(r => new SubmittedRequestViewModel()
				{
					Id = r.Id,
					DateCreated = r.DateCreated.ToString(DateFormat),
					UserEmail = r.User.Email,
					ExerciseName = r.ExerciseName,
					ExerciseDescription = r.ExerciseDescription,
                    ExerciseMuscleGroup = r.MuscleGroupe,
					ExerciseNewName = r.ExerciseNewName,
					ExerciseNewDescription = r.ExerciseNewDescription,
					RequestType = r.RequestType.ToString(),
                    ChaneMuscleGroup = r.ChangeMuscleGroup.ToString(),
                    DateApproved = r.DateDone.ToString(),
                    RequestStatus = r.RequestStatus.ToString(),
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<SubmittedRequestViewModel>> GetPendingRequestsAsync()
        {
            return await repository.AllReadOnly<Requests>()
                .Where(r => r.RequestStatus == RequestStatus.Pending.ToString())
                .OrderBy(r => r.DateCreated)
                .Select(r => new SubmittedRequestViewModel()
                {
                    Id = r.Id,
                    DateCreated = r.DateCreated.ToString(DateFormat),
                    UserEmail = r.User.Email,
                    ExerciseName = r.ExerciseName,
                    ExerciseDescription = r.ExerciseDescription,
                    ExerciseMuscleGroup = r.MuscleGroupe,
                    ExerciseNewName = r.ExerciseNewName,
                    ExerciseNewDescription = r.ExerciseNewDescription,
                    RequestType = r.RequestType.ToString(),
                    ChaneMuscleGroup = r.ChangeMuscleGroup.ToString(),
                    DateApproved = r.DateDone.ToString(),
                    RequestStatus = r.RequestStatus.ToString(),
                })
                .ToListAsync();
        }

        public async Task<SubmittedRequestViewModel> GetRequestsAsync(int id)
        {
            return await repository.All<Requests>()
                .Select(r => new SubmittedRequestViewModel()
                {
                    Id = r.Id,
                    DateCreated = r.DateCreated.ToString(DateFormat),
                    UserEmail = r.User.Email,
                    ExerciseName = r.Exercise.Name,
                    ExerciseDescription = r.Exercise.Description,
                    ExerciseMuscleGroup = r.MuscleGroupe,
                    RequestType = r.RequestType.ToString(),
                    ExerciseNewName = r.ExerciseNewName,
                    ExerciseNewDescription = r.ExerciseNewDescription,
                    RequestStatus = r.RequestStatus.ToString(),
                    DateApproved = r.DateDone.ToString(),
                    ChaneMuscleGroup = r.ChangeMuscleGroup.ToString()
                })
                .FirstAsync(r => r.Id == id);
        }
    }
}
