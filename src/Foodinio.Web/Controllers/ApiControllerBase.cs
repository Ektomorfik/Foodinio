using System;
using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    [Route("api/[controller]")]
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;
        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command is IAuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}