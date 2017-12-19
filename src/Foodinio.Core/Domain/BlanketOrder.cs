using System;
using System.Collections.Generic;

namespace Foodinio.Core.Domain
{
    public class BlanketOrder : BaseEntity
    {
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual IEnumerable<Dish> Meal { get; protected set; }
        public decimal TotalPrice { get; protected set; }
    }
}