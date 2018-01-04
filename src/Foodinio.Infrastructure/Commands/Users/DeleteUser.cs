using System;

namespace Foodinio.Infrastructure.Commands.Users
{
    public class DeleteUser : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}