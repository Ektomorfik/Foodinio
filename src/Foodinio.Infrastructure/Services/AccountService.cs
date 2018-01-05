using System;
using System.Threading.Tasks;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Exceptions;
using Foodinio.Infrastructure.Extensions;
using Foodinio.Infrastructure.Services.Encryption;

namespace Foodinio.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        public AccountService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task UpdateAsync(Guid userId, string email, string firstName, string lastName)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            user.SetEmail(email);
            user.SetFirstName(firstName);
            user.SetLastName(lastName);

            await _userRepository.UpdateAsync(user);
        }

        public async Task ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetOrFailAsync(userId);

            var currentHash = _encrypter.GetHash(currentPassword, user.Salt);
            if (currentHash != user.Password)
            {
                throw new ServiceException(ErrorCodes.InvalidPassword, "Passwords are different.");
            }

            var salt = _encrypter.GetSalt(newPassword);
            var password = _encrypter.GetHash(newPassword, salt);
            user.SetPassword(password, salt);

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.RemoveAsync(id);
        }

    }
}