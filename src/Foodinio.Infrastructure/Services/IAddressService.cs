using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Infrastructure.DTO;

namespace Foodinio.Infrastructure.Services
{
    public interface IAddressService : IService
    {
        Task<IEnumerable<AddressDTO>> BrowseAsync(Guid userId);
        Task AddAsync(Guid id, Guid userId, string city, string street, string houseNumber, string postalCode);
        Task DeleteAsync(Guid id);
    }
}