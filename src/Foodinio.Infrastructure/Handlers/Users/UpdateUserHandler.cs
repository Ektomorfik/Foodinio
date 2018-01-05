using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser>
    {
        private readonly IUserService _userService;
        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(UpdateUser command)
        {
            await _userService.UpdateAsync(command.UserId, command.Email, command.FirstName, command.LastName);
        }
    }
}