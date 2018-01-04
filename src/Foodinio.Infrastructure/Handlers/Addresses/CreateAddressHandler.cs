using System;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Addresses;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Addresses
{
    public class CreateAddressHandler : ICommandHandler<CreateAddress>
    {
        private readonly IAddressService _addressService;
        public CreateAddressHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }
        public async Task HandleAsync(CreateAddress command)
        {
            await _addressService.AddAsync(command.Id, command.UserId,
            command.City, command.Street, command.HouseNumber, command.PostalCode);
        }
    }
}