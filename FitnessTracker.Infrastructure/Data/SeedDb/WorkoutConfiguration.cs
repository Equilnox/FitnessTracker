using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
    internal class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            var data = new SeedData();

            builder.HasData(new Workout[]
            {
                data.TestWorkoutOne,
                data.TestWorkoutTwo,
                data.TestWorkoutThree,
                data.TestWorkoutFour,
                data.TestWorkoutFive,
                data.TestWorkoutSix
            });
        }
    }
}
