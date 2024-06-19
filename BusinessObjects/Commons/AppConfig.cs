
namespace BusinessObjects.Commons
{
    public class AppConfig
    {
        public static JwtSetting JwtSetting { get; set; } = null!;
    }
    public class JwtSetting
    {
        public string SecretKey { get; set; } = "Secret Key";
        public bool ValidateIssuerSigningKey { get; set; }
        public string? IssuerSigningKey { get; set; }
        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }
        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }
        public bool RequireExpirationTime { get; set; }
    }
}
