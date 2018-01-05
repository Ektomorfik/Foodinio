using System.Threading.Tasks;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Exceptions;
using Foodinio.Infrastructure.Services.Encryption;

namespace Foodinio.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        public LoginService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
            }
            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }

            throw new ServiceException(ErrorCodes.InvalidCredentials, "Invalid credentials");
        }
    }
}