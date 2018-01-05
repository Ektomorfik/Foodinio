using System.Threading.Tasks;
using Foodinio.Infrastructure.Commands;
using Foodinio.Infrastructure.Commands.Login;
using Foodinio.Infrastructure.Extensions;
using Foodinio.Infrastructure.Services;
using Foodinio.Infrastructure.Services.JWT;
using Microsoft.Extensions.Caching.Memory;

namespace Foodinio.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IMemoryCache _cache;
        private readonly IJwtHandler _jwtHandler;
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        public LoginHandler(IMemoryCache cache, IJwtHandler jwtHandler, ILoginService loginService, IUserService userService)
        {
            _cache = cache;
            _jwtHandler = jwtHandler;
            _loginService = loginService;
            _userService = userService;
        }
        public async Task HandleAsync(Login command)
        {
            await _loginService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}