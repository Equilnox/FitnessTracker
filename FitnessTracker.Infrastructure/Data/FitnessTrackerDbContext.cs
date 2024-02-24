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
    }
}
