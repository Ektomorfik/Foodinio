using System;
using System.Collections.Generic;

namespace Foodinio.Core.Domain
{
    public class Order : BaseEntity
    {
        public virtual User User { get; protected set; }
        public Guid BlanketOrderId { get; protected set; }
        public virtual BlanketOrder BlanketOrder { get; protected set; }
        public virtual Address Address { get; protected set; }
        public decimal TotalPrice { get; protected set; }
        protected Order()
        {

        }
    }
}