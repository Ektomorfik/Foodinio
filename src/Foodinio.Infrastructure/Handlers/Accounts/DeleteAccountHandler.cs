using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Accounts;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Accounts
{
    public class DeleteAccountHandler : ICommandHandler<DeleteAccount>
    {
        private readonly IAccountService _accountService;
        public DeleteAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task HandleAsync(DeleteAccount command)
        {
            await _accountService.DeleteAsync(command.UserId);
        }
    }
}