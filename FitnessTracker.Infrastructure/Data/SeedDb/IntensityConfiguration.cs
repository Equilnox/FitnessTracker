using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
    internal class IntensityConfiguration : IEntityTypeConfiguration<Intensity>
    {
        public void Configure(EntityTypeBuilder<Intensity> builder)
        {
            var data = new SeedData();

            builder.HasData(new Intensity[]
            {
                data.TestIntensityOne,
                data.TestIntensityTwo,
                data.TestIntensityThree,
                data.TestIntensityFour,
                data.TestIntensityFive,
                data.TestIntensitySix,
                data.TestIntensitySeven,
                data.TestIntensityEight,
                data.TestIntensityNine,
                data.TestIntensityTen,
                data.TestIntensityEleven,
                data.TestIntensityTwelve,
                data.TestIntensityThirteen,
                data.TestIntensityFourteen,
                data.TestIntensityFifteen,
                data.TestIntensitySixteen,
                data.TestIntensitySeventeen,
                data.TestIntensityEighteen,
                data.TestIntensityNineteen,
                data.TestIntensityTwenty,
                data.TestIntensityTwentyOne,
                data.TestIntensityTwentyTwo,
                data.TestIntensityTwentyThree,
                data.TestIntensityTwentyFour,
                data.TestIntensityTwentyFive,
                data.TestIntensityTwentySix,
                data.TestIntensityTwentySeven,
                data.TestIntensityTwentyEight,
                data.TestIntensityTwentyNine,
                data.TestIntensityThirty
            });
        }
    }
}
