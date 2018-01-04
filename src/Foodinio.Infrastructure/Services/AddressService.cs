using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.DTO;
using Foodinio.Infrastructure.Exceptions;

namespace Foodinio.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDTO>> BrowseAsync(Guid userId)
        {
            var addresses = await _addressRepository.BrowseAsync(userId);
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
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