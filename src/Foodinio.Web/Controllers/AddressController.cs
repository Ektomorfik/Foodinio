using System;
using System.Threading.Tasks;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Addresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    public class AddressController : ApiControllerBase
    {
        public AddressController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CreateAddress command)
        {
            command.Id = Guid.NewGuid();
            await DispatchAsync(command);
            return Created($"address/{command.Id}", null);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await DispatchAsync(new DeleteAddress(id));
            return NoContent();
        }
    }
}