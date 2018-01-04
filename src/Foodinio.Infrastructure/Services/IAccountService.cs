using System;
using System.Threading.Tasks;

namespace Foodinio.Infrastructure.Services
{
    public interface IAccountService : IService
    {
        Task DeleteAsync(Guid id);
        Task ChangePassword(Guid userId, string currentPassword, string newPassword);
    }
}