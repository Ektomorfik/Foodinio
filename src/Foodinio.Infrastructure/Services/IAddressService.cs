using System;
using System.Threading.Tasks;

namespace Foodinio.Infrastructure.Services
{
    public interface IAddressService : IService
    {
        Task AddAsync(Guid id, Guid userId, string city, string street, string houseNumber, string postalCode);
        Task DeleteAsync(Guid id);
    }
}