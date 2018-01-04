using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await DispatchAsync(new DeleteAccount());
            return NoContent();
        }
    }
}