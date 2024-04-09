using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Services;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class FitnessTrackerCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IGymService, GymService>();
            services.AddScoped<IAthleteService, AthleteService>();
			services.AddScoped<IAthleteGymService, AthleteGymService>();
            services.AddScoped<IWorkoutService, WorkoutService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<FitnessTrackerDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FitnessTrackerDbContext>();

            return services;
        }
    }
}
