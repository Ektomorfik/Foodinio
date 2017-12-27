namespace Foodinio.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }

        public JwtSettings(string key, string issuer, int expiryMinutes)
        {
            Key = key;
            Issuer = issuer;
            ExpiryMinutes = expiryMinutes;
        }
    }
}