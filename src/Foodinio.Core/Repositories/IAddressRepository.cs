using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Core.Domain;

namespace Foodinio.Core.Repositories
{
    public interface IAddressRepository : IRepository
    {
        Task<Address> GetAsync(Guid id);
        Task<IEnumerable<Address>> GetAllAsync();
        Task AddAsync(Address address);
        Task RemoveAsync(Address address);
    }
}