using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
