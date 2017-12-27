using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Infrastructure.DTO;

namespace Foodinio.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetAsync(Guid userId);
        Task<UserDTO> GetAsync(string email);
        Task<IEnumerable<UserDTO>> BrowseAsync();
        Task LoginAsync(string email, string password);
        Task RegisterAsync(Guid userId, string email, string firstName, string lastName, string password, string role);
    }
}