namespace Foodinio.Infrastructure.Services.Encryption
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}