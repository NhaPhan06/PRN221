﻿namespace DataAccess.DataAccess;

public class Order
{
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? RequireDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public string? ShipAddress { get; set; }
    public string? Status { get; set; }
    public Guid? CustomerId { get; set; }
    public decimal? Price { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}