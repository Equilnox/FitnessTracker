using FitnessTracker.Infrastructure.Data.Models;
using FitnessTracker.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Data
{
    public class FitnessTrackerDbContext : IdentityDbContext
    {
        public FitnessTrackerDbContext(DbContextOptions<FitnessTrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AthleteConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new GymConfiguration());
            builder.ApplyConfiguration(new AthletesGymConfiguration());
            builder.ApplyConfiguration(new WorkoutConfiguration());
            builder.ApplyConfiguration(new IntensityConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Intensity> Intensities { get; set; }

        public DbSet<Gym> Gyms { get; set; }

        public DbSet<AthleteGym> AthletesGyms { get; set; }
    }
}
