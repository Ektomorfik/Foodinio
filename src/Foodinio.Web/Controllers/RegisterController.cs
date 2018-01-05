using System;
using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    public class RegisterController : ApiControllerBase
    {
        public RegisterController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            command.Id = Guid.NewGuid();
            await DispatchAsync(command);
            return Created($"users/{command.Id}", null);
        }

    }
}