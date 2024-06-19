using BadmintonRentalPlatformAPI.Configuration;
using BusinessObjects.Commons;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.Get<AppConfig>() ?? new AppConfig();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddCloudinarySetting(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddSeeding();
builder.Services.AddSwaggerAuthorization();
builder.Services.AddJwtAuthentication(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Configuration
builder.Configuration.SettingsBinding();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors(options =>
    options.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000", "http://localhost:8081"));
app.MapControllers();

app.Run();