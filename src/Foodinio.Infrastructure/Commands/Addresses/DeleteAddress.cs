using System;

namespace Foodinio.Infrastructure.Commands.Addresses
{
    public class DeleteAddress : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

        public DeleteAddress(Guid id)
        {
            Id = id;
        }
    }
}