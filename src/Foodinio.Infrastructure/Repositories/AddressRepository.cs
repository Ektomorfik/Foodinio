using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.EF;
using Foodinio.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Foodinio.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly FoodinioContext _context;
        private readonly DbSet<Address> _addresses;
        public AddressRepository(FoodinioContext context)
        {
            _context = context;
            _addresses = context.DeliveryAddresses;
        }

        public async Task<Address> GetAsync(Guid id)
            => await _addresses.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Address>> GetAllAsync()
            => await _addresses.ToListAsync();

        public async Task AddAsync(Address address)
        {
            await _addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Address address)
        {
            _addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}