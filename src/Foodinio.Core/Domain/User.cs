using System.Collections.Generic;

namespace Foodinio.Core.Domain
{
    public class User : BaseEntity
    {
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Salt { get; protected set; }
        public string Password { get; protected set; }

        // public Role Role { get; set; }
        public virtual IEnumerable<DeliveryAddress> Addresses { get; protected set; }
        public virtual IEnumerable<Order> Orders { get; protected set; }

        protected User()
        {

        }


    }
}