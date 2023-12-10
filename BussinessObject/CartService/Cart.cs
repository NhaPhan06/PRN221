namespace BussinessObject.CartService;

public class Cart
{
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
}