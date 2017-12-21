using System;
using System.Collections.Generic;
using Foodinio.Core.Domain;

namespace Foodinio.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public IEnumerable<DeliveryAddressDTO> Addresses { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}