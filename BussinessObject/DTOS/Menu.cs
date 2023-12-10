namespace BussinessObject.DTOS;

public class Menu
{
    public Menu(Guid id, string name, decimal? unitPrice, string image, int? quantity, string categoryName, string supplierName, string? status)
    {
        Id = id;
        Name = name;
        UnitPrice = unitPrice;
        Image = image;
        Quantity = quantity;
        CategoryName = categoryName;
        SupplierName = supplierName;
        Status = status;
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal? UnitPrice { get; set; }
    public string Image { get; set; } = null!;
    public int? Quantity { get; set; }
    public String CategoryName { get; set; }
    public String SupplierName { get; set; }
    public string? Status { get; set; }
}