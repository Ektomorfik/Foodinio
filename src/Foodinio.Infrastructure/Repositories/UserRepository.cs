using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;

namespace Foodinio.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User(Guid.NewGuid(), "user1@email.com", "Krystian", "Janicki", "secret", "salt", "user"),
            new User(Guid.NewGuid(), "user2@email.com", "Zbigniew", "Wesołowski", "secret", "salt", "user"),
            new User(Guid.NewGuid(), "admin1@email.com", "Janusz", "Zbiciak", "secret", "salt", "admin"),
        };
        public Task<User> GetAsync(Guid userId)
        {
            return Task.FromResult(_users.SingleOrDefault(x => x.Id == userId));
        }

        public Task<User> GetAsync(string email)
        {
            return Task.FromResult(_users.SingleOrDefault(x => x.Email == email));
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(User user)
        {
            return Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid userId)
        {
            var user = await GetAsync(userId);
            _users.Remove(user);
        }
    }
}