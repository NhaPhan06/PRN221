using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
