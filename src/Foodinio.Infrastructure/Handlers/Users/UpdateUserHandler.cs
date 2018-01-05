using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser>
    {
        private readonly IAccountService _accountService;
        public UpdateUserHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task HandleAsync(UpdateUser command)
        {
            await _accountService.UpdateAsync(command.UserId, command.Email, command.FirstName, command.LastName);
        }
    }
}