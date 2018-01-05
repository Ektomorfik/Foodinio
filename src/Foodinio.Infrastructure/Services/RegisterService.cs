using System;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Exceptions;
using Foodinio.Infrastructure.Services.Encryption;

namespace Foodinio.Infrastructure.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        public RegisterService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }
        public async Task RegisterAsync(Guid userId, string email, string firstName, string lastName, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ServiceException(ErrorCodes.UserAlreadyExists, $"User with email: '{user.Email}' already exists.");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, firstName, lastName, hash, salt, role);
            await _userRepository.AddAsync(user);
        }
    }
}