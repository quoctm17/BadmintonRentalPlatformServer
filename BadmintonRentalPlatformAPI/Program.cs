using BadmintonRentalPlatformAPI.Configuration;
using BadmintonRentalPlatformAPI.Middlewares;
using BusinessObjects.Commons;
using DataAccessObject;
using DataAccessObject.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.Get<AppConfig>() ?? new AppConfig();


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddCloudinarySetting(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.RegisterMapster();
builder.Services.AddSeeding();
builder.Services.AddSwaggerAuthorization();
builder.Services.AddJwtAuthentication(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:5135",
                    "https://localhost:7043")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

// Add Configuration
builder.Configuration.SettingsBinding();

// Register AppDbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseCors("AllowSpecificOrigins");
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
    await Seed.SeedNotifications(context);
    await Seed.SeedBadmintonCourts(context);
    await Seed.SeedTypeOfCourts(context);
    await Seed.SeedCourts(context);
    await Seed.SeedPayments(context);
    await Seed.SeedCourtImages(context);

}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding data");
}

app.Run();