using System;

namespace Foodinio.Infrastructure.Commands.Accounts
{
    public class DeleteAccount : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
    }
}