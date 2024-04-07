using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
    internal class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
            var data = new SeedData();

            builder.HasData(new Athlete[] { data.TestAthleteOne, data.TestAthleteTwo, data.AdminAthlete });
        }
    }
}
