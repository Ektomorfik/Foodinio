using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IUserService _userService;
        public ChangeUserPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await _userService.ChangePassword(command.UserId, command.CurrentPassword, command.NewPassword);
        }
    }
}