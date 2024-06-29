using Mapster;
using System.Reflection;

namespace BadmintonRentalPlatformAPI.Configuration
{
    public static class ConfigureMapster
    {
        public static IServiceCollection RegisterMapster (this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Default.IgnoreNullValues(true);

            var assemblies = new Assembly[]
            {
                Assembly.GetExecutingAssembly(),
            };

            config = config.ConfigCustomMapper();

            config.Scan(assemblies);

            services.AddMapster();
            return services;
        }

        private static TypeAdapterConfig ConfigCustomMapper(this TypeAdapterConfig config)
        {
            return config;
        }
    }
}
