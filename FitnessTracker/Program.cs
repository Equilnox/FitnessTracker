using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(
    options =>
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    }
);

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Exercise Details",
        pattern: "Exercise/Details/{id}/{information}",
        defaults: new { Controller = "Exercise", Action = "Details" });

    endpoints.MapControllerRoute(
        name: "Gym Details",
        pattern: "Gym/Details/{id}/{information}",
        defaults: new { Controller = "Gym", Action = "Details" });

    endpoints.MapControllerRoute(
        name: "Edit Gym Details",
        pattern: "Gym/Edit/{id}/{information}",
        defaults: new { Controller = "Gym", Action = "Edit" });

    endpoints.MapControllerRoute(
        name: "Request Details",
        pattern: "Request/EditExercise/{id}/{information}",
        defaults: new { Controller = "Request", Action = "EditExercise" });

    endpoints.MapControllerRoute(
        name: "Edit Athlete Details",
        pattern: "Athlete/Edit/{id}/{information}",
        defaults: new { Controller = "Athlete", Action = "Edit" });

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();

await app.RunAsync();
