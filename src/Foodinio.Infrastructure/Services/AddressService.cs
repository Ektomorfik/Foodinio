using System;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Exceptions;

namespace Foodinio.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string city, string street, string houseNumber, string postalCode)
        {
            var address = new Address(id, userId, city, street, houseNumber, postalCode);
            await _addressRepository.AddAsync(address);
        }

        public async Task DeleteAsync(Guid id)
        {
            var address = await _addressRepository.GetAsync(id);
            if (address == null)
            {
                throw new ServiceException(ErrorCodes.AddressNotFound, $"Address with id: '{id}' was not found.");
            }

            await _addressRepository.RemoveAsync(address);
        }
    }
}