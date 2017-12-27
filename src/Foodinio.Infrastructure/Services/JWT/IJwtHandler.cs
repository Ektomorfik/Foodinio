using System;
using Foodinio.Infrastructure.DTO;

namespace Foodinio.Infrastructure.Services.JWT
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(Guid userId, string role);
    }
}