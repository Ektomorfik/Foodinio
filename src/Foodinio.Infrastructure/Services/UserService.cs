using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.DTO;
using Foodinio.Infrastructure.Exceptions;
using Foodinio.Infrastructure.Extensions;
using Foodinio.Infrastructure.Services.Encryption;

namespace Foodinio.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            var user = await _userRepository.GetOrFailAsync(email);

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<IEnumerable<UserDTO>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
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
                throw new ServiceException(ErrorCodes.InvalidPassword, "Invalid password.");
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