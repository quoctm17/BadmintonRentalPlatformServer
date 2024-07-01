using System.Text;
using BadmintonRentalPlatformAPI.Configuration.Domain;
using BusinessObjects.Commons;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories;
using Repositories.Interface;
using Repositories.Mappings;
using Services;
using Services.Interface;

namespace BadmintonRentalPlatformAPI.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBadmintonCourtRepository, BadmintonCourtRepository>();
        services.AddScoped<ITypeOfCourtRepository, TypeOfCourtRepository>();
        services.AddScoped<ICourtRepository, CourtRepository>();
        services.AddScoped<ICourtSlotRepository, CourtSlotRepository>();
        return services;
    }

    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBadmintonCourtService, BadmintonCourtService>();
        services.AddScoped<ITypeOfCourtService, TypeOfCourtService>();
        services.AddScoped<ICourtService, CourtService>();
        services.AddScoped<ICourtSlotService, CourtSlotService>();
        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = AppConfig.JwtSetting.ValidIssuer,
                ValidateIssuer = AppConfig.JwtSetting.ValidateIssuer,
                ValidateActor = true,
                ValidateAudience = AppConfig.JwtSetting.ValidateAudience,
                ValidAudience = AppConfig.JwtSetting.ValidAudience,
                RequireExpirationTime = AppConfig.JwtSetting.RequireExpirationTime,
                ValidateIssuerSigningKey = AppConfig.JwtSetting.ValidateIssuerSigningKey,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.JwtSetting.SecretKey))
            };
        });
        return services;
    }

    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddScoped<Seeding>();
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(AutoMapperProfiles));
        return services;
    }

    public static IServiceCollection AddSwaggerAuthorization(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "BadmintonRentalPlatform", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }

    public static IServiceCollection AddCloudinarySetting(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySettings"));
        return services;
    }
}