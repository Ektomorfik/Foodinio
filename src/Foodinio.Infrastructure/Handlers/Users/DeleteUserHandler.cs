using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IUserService _userService;
        public DeleteUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(DeleteUser command)
        {
            await _userService.DeleteAsync(command.UserId);
        }
    }
}