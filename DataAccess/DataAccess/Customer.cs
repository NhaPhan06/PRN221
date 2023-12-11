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
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
