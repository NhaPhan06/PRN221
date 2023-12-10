﻿using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
