using System;
using System.Threading.Tasks;

namespace Foodinio.Infrastructure.Services
{
    public interface IAccountService : IService
    {
        Task DeleteAsync(Guid id);
    }
}