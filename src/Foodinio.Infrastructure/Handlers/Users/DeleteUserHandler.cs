using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IAccountService _accountService;
        public DeleteUserHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task HandleAsync(DeleteUser command)
        {
            await _accountService.DeleteAsync(command.UserId);
        }
    }
}