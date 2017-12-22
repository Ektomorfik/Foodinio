using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Foodinio.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodinioContext _context;
        private readonly DbSet<User> _users;
        public UserRepository(FoodinioContext context)
        {
            _context = context;
            _users = context.Users;
        }
        public Task<User> GetAsync(Guid id)
            => _users.SingleOrDefaultAsync(x => x.Id == id);

        public Task<User> GetAsync(string email)
            => _users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _users.ToListAsync();

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}