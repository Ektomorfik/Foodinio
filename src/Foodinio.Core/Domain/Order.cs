using System;
using System.Collections.Generic;

namespace Foodinio.Core.Domain
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public Guid BlanketOrderId { get; protected set; }
        public virtual BlanketOrder BlanketOrder { get; protected set; }
        public Guid DeliveryAddressId { get; protected set; }
        public virtual DeliveryAddress DeliveryAddress { get; protected set; }
        public decimal TotalPrice { get; protected set; }
        protected Order()
        {

        }
    }
}