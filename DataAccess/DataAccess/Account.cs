using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Status { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
