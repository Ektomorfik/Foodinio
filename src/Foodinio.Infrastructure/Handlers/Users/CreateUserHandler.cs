using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Users;
using Foodinio.Infrastructure.Services;

namespace Foodinio.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IRegisterService _registerService;

        public CreateUserHandler(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _registerService.RegisterAsync(command.Id, command.Email,
                command.FirstName, command.LastName, command.Password, command.Role);
        }
    }
}