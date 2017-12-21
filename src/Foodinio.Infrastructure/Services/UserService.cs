using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.DTO;
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


        public Task<UserDTO> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetAsync(string email)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<UserDTO>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task RegisterAsync(Guid userId, string email, string firstName, string lastName, string password, string role)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user != null)
            {
                throw new Exception();
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, firstName, lastName, hash, salt, role);
            await _userRepository.AddAsync(user);
        }
    }
}