using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
    internal class AthletesGymConfiguration : IEntityTypeConfiguration<AthleteGym>
    {
        public void Configure(EntityTypeBuilder<AthleteGym> builder)
        {

            builder.HasKey(ag => new { ag.AthleteId, ag.GymId });

            var data = new SeedData();

            builder.HasData(new AthleteGym[] { data.TestAthleteOneGymOne, data.TestAthleteTwoGymOne });
        }
    }
}
