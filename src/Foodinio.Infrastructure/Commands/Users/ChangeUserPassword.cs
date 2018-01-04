using System;

namespace Foodinio.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}