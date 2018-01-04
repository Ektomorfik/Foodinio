using System;

namespace Foodinio.Infrastructure.DTO
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string HouseNumber { get; protected set; }
        public string PostalCode { get; protected set; }
    }
}