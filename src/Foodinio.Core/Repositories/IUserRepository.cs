using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Core.Domain;

namespace Foodinio.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid id);
    }
}