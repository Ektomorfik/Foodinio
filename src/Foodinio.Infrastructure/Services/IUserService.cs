using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Infrastructure.DTO;

namespace Foodinio.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetAsync(string email);
        Task<IEnumerable<UserDTO>> BrowseAsync();
        Task UpdateAsync(Guid userId, string email, string firstName, string lastName);
        Task DeleteAsync(Guid id);
        Task ChangePassword(Guid userId, string currentPassword, string newPassword);

    }
}