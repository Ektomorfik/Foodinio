using System.Threading.Tasks;

namespace Foodinio.Infrastructure.Services
{
    public interface ILoginService : IService
    {
        Task LoginAsync(string email, string password);
    }
}