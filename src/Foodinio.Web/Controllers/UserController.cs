using System;
using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    [Authorize]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();
            return Json(users);
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