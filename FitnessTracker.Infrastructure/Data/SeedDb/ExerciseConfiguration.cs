using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
    internal class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            var data = new SeedData();

            builder.HasData(new Exercise[] 
            { 
                    data.ExerciseOne, 
                    data.ExerciseTwo, 
                    data.ExerciseThree,
                    data.ExerciseFour, 
                    data.ExerciseFive, 
                    data.ExerciseSix 
            });
        }
    }
}
