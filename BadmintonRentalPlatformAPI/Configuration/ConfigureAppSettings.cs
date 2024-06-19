using BusinessObjects.Commons;

namespace BadmintonRentalPlatformAPI.Configuration
{
    public static class ConfigureAppSettings
    {
        public static void SettingsBinding(this IConfiguration configuration)
        {

            AppConfig.JwtSetting = new JwtSetting();

            configuration.Bind("Jwt", AppConfig.JwtSetting);

        }
    }
}
