using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        private readonly IAccountService _accountService;
        public ChangeUserPasswordHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await _accountService.ChangePassword(command.UserId, command.CurrentPassword, command.NewPassword);
        }
    }
}