using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }
        public Guid? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
