using System;

namespace Foodinio.Infrastructure.Commands.Addresses
{
    public class UpdateAddress : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
    }
}