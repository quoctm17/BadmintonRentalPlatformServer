using DataAccessObject.Seed;
using DataAccessObject;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedRoles(context);
    await Seed.SeedUsers(context);
    await Seed.SeedUserRoles(context);
    await Seed.SeedNotifications(context);
    await Seed.SeedBadmintonCourts(context);
    await Seed.SeedTypeOfCourts(context);
    await Seed.SeedCourts(context);
    await Seed.SeedSlots(context);
    await Seed.SeedCourtSlots(context);
    await Seed.SeedPayments(context);

}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding data");
}


app.Run();
