using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Athlete;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> ExistsById(string UserId)
        {
            return await repository.AllReadOnly<Athlete>().AnyAsync(a => a.UserId == UserId);
        }

        public async Task<AthleteViewModel> GetAthlete(string userId)
        {
            var athletes = await repository.AllReadOnly<Athlete>()
                .Select(a => new AthleteViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
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

        public async Task AddNewAthleteAsync(AthleteCreateFormModel model, string userId)
        {
            Athlete athlete = new Athlete()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = userId
			};

            await repository.AddAsync(athlete);

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }
    }
}
