using System;

namespace Foodinio.Infrastructure.Commands.Users
{
    public class UpdateUser : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}