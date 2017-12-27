using System;

namespace Foodinio.Core.Domain
{
    public class DeliveryAddress : BaseEntity
    {
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual Order Order { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string HouseNumber { get; protected set; }
        public string PostalCode { get; protected set; }

        protected DeliveryAddress()
        {

        }
    }
}