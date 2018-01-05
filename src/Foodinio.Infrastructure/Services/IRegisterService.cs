using System;
using System.Threading.Tasks;

namespace Foodinio.Infrastructure.Services
{
    public interface IRegisterService : IService
    {
        Task RegisterAsync(Guid userId, string email, string firstName, string lastName, string password, string role);
    }
}