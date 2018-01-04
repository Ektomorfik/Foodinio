using System;
using System.Threading.Tasks;
using Foodinio.Core.Repositories;

namespace Foodinio.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.RemoveAsync(id);
        }
    }
}