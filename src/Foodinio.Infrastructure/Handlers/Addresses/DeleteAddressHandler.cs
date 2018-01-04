using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Addresses;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Addresses
{
    public class DeleteAddressHandler : ICommandHandler<DeleteAddress>
    {
        private readonly IAddressService _addressService;
        public DeleteAddressHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task HandleAsync(DeleteAddress command)
        {
            await _addressService.DeleteAsync(command.Id);
        }
    }
}