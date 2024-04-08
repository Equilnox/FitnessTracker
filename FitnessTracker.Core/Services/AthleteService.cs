using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Athlete;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Core.Services
{
	public class AthleteService : IAthleteService
    {
        private readonly IRepository repository;

        public AthleteService(IRepository _repository)
        {
            repository = _repository;
        }

		/// <summary>
		/// Check if athlete exists.
		/// </summary>
		/// <param name="UserId"></param>
		/// <returns></returns>
		public async Task<bool> ExistsById(string UserId)
        {
            return await repository.AllReadOnly<Athlete>().AnyAsync(a => a.UserId == UserId);
        }

		/// <summary>
		/// Return athlete data.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public async Task<AthleteViewModel> GetAthlete(string userId)
        {
            var athletes = await repository.AllReadOnly<Athlete>()
                .Select(a => new AthleteViewModel
                {
                    Id = a.Id,
                    FirstName = a.User.FirstName,
                    LastName = a.User.LastName,
                    ProfilePictureURL = a.ProfilePictureURL,
                    Age = a.Age,
                    Height = a.Height,
                    Weight = a.Weight,
                    UserId = a.UserId
                })
                .ToListAsync();


            if(!athletes.Any(a => a.UserId == userId))
            {
                return null;
            }

            var athlete = athletes.Find(x => x.UserId == userId);

            athlete.AthletesGym = await GetGymMembershipsAsync(athlete.Id);

            athlete.Workouts = await GetAthleteWorkoutsAsync(athlete.Id);

            return athlete;
        }

		/// <summary>
		/// Return Athletes memberships.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IEnumerable<AthleteGymsViewModel>> GetGymMembershipsAsync(int id)
        {
            var memberships = await repository.AllReadOnly<AthleteGym>()
                .Select(m => new AthleteGymsViewModel
                {
                    AthleteId = m.AthleteId,
                    GymId = m.GymId,
                    GymName = m.Gym.Name,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate
                })
                .ToListAsync();

            if(!memberships.Any(a => a.AthleteId == id))
            {
                return new List<AthleteGymsViewModel>();
            }

            memberships = memberships.Select(m => m).Where(m => m.AthleteId == id).ToList();

            return memberships;
        }

		/// <summary>
		/// Return Athlete workouts.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IEnumerable<AthleteWorkoutsViewModel>> GetAthleteWorkoutsAsync(int id)
        {
            var workouts = await repository.AllReadOnly<Workout>()
                .Select(w => new AthleteWorkoutsViewModel
                {
                    Id = w.Id,
                    AthleteId = w.AthleteId,
                    WorkoutType = w.WorkoutType.ToString(),
                    Date = w.Date.ToShortDateString(),
                    GymName = w.Gym.Name,
                })
                .ToListAsync();

            if (!workouts.Any(w => w.AthleteId == id))
            {
                return new List<AthleteWorkoutsViewModel>();
            }

            workouts = workouts.Select(w => w).Where(w => w.AthleteId == id).ToList();

            var workoutIds = workouts.Select(w => w.Id);

            var exercisesForWorkouts = await GetExercisesForWorkoutsAsync(workoutIds);

            foreach(var workout in workouts)
            {
                var exercisesForThisWorkout = new List<AthleteExerciseIntensity> ();

                foreach(var exercise in exercisesForWorkouts)
                {
                    if (exercise.WorkoutId == workout.Id)
                    {
                        exercisesForThisWorkout.Add(exercise);
                    }
                }

                workout.Exercises = exercisesForThisWorkout;
            }

            return workouts;
        }

		/// <summary>
		/// Return exercises for a workout.
		/// </summary>
		/// <param name="workoutIds"></param>
		/// <returns></returns>
		public async Task<IEnumerable<AthleteExerciseIntensity>> GetExercisesForWorkoutsAsync(IEnumerable<int> workoutIds)
        {
            var exercisesFromDB = await repository.AllReadOnly<Intensity>()
                .Select(e => new AthleteExerciseIntensity
                {
                    Id = e.Id,
                    WorkoutId = e.WorkoutId,
                    ExerciseName = e.Exercise.Name,
                    LiftedWeight = e.LiftedWeight,
                    Repetitions = e.Repetitions,
                    Seconds = e.Seconds,
                    Sets = e.Sets
                })
                .ToListAsync();

            List<AthleteExerciseIntensity> exercises = new List<AthleteExerciseIntensity>();

            foreach(var workoutId in workoutIds)
            {
                foreach (var exerciseFromDb in exercisesFromDB)
                {
                    if(exerciseFromDb.WorkoutId == workoutId)
                    {
                        exercises.Add(exerciseFromDb);
                    }
                }
            }

            return exercises;
        }

		/// <summary>
		/// Create new Athlete entity after register.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
		public async Task AddNewAthleteAsync(AthleteCreateFormModel model, string userId)
        {
            var user = await repository.All<ApplicationUser>()
                .FirstOrDefaultAsync(x => x.Id == userId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            Athlete athlete = new Athlete()
            {
                UserId = userId
			};

            await repository.AddAsync(athlete);

            await SaveAsync();
        }

		/// <summary>
		/// Save asynchronously new Athlete Entity.
		/// </summary>
		/// <returns></returns>
		public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }

        /// <summary>
        /// Returns Athlete details to be edited.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AthleteDetailsEditFormModel> FindByIdAsync(int id)
        {
            var model = await repository.All<Athlete>()
                .Select(a => new AthleteDetailsEditFormModel()
                {
                    Id = a.Id,
                    Age = a.Age,
                    Height = a.Height,
                    Weight = a.Weight
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return model;
        }

        /// <summary>
        /// Method is used for changing Athlete basic data in DB.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public async Task EditDetailsAsync(AthleteDetailsEditFormModel model)
		{
			var athlete = await repository.All<Athlete>().FirstAsync(a => a.Id == model.Id);
            var user = await repository.All<ApplicationUser>().FirstAsync(x => x.Id == athlete.UserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            athlete.Age = model.Age;
            athlete.Height = model.Height;
            athlete.Weight = model.Weight;
		}

        /// <summary>
        /// Method to check if the current user and athlete are the same person.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="athleteId"></param>
        /// <returns></returns>
		public async Task<bool> CheckUserId(string userId, int athleteId)
		{
			var athlete = await repository.AllReadOnly<Athlete>()
                .FirstAsync(a => a.Id == athleteId);

            bool isValid = false;

            if(userId == athlete.UserId)
            {
                isValid = true;
            }

            return isValid;
		}
	}
}
