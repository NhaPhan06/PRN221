namespace DataAccess.DataAccess;

public class Product
{
    public Product()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal? UnitPrice { get; set; }
    public string Image { get; set; } = null!;
    public int? Quantity { get; set; }
    public string? Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}