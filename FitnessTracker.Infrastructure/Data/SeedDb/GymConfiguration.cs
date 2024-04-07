using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessTracker.Infrastructure.Data.SeedDb
{
	internal class GymConfiguration : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
			var data = new SeedData();

            builder
                .HasOne(u => u.Owner)
                .WithOne()
                .HasForeignKey<Gym>(g => g.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

			builder.HasData(new Gym[] { data.GymOne, data.GymTwo, data.AdminGym });
        }
    }
}
