using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    [Route("api/[controller]")]
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}