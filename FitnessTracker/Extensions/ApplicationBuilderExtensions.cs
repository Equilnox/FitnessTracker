using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using static FitnessTracker.Core.Constants.RoleConstants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var applicationScope = app.ApplicationServices.CreateScope();
            var userManager = applicationScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = applicationScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if(userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdministratorRole) == false)
            {
                var role = new IdentityRole(AdministratorRole);

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("admin@mail.com");

                if(admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }
        }
    }
}
