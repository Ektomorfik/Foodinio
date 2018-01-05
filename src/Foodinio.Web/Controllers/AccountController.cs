using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    [Authorize]
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangeUserPassword command)
        {
            await DispatchAsync(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateUser command)
        {
            await DispatchAsync(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await DispatchAsync(new DeleteUser());
            return NoContent();
        }
    }
}